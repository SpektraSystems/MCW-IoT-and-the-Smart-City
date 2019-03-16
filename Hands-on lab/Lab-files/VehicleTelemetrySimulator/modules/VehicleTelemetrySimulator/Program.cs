namespace VehicleTelemetrySimulator
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.Loader;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Client;
    using Microsoft.Azure.Devices.Client.Transport.Mqtt;
    using Microsoft.Azure.Devices.Shared;
    using Newtonsoft.Json;

    class Program
    {
        static int counter;
        static Random random = new Random();
        static double highSpeedProbabilityPower = 0.3;
        static double lowSpeedProbabilityPower = 0.9;
        static double highOilProbabilityPower = 0.3;
        static double lowOilProbabilityPower = 1.2;
        static double highTirePressureProbabilityPower = 0.5;
        static double lowTirePressureProbabilityPower = 1.7;
        static double highOutsideTempProbabilityPower = 0.3;
        static double lowOutsideTempProbabilityPower = 1.2;
        static double highEngineTempProbabilityPower = 0.3;
        static double lowEngineTempProbabilityPower = 1.2;
        static string vin { get; set; }
        static string borough { get; set; }

        static void Main(string[] args)
        {
            // The Edge runtime gives us the connection string we need -- it is injected as an environment variable
           // string connectionString = "HostName=iothub-f5qzr.azure-devices.net;DeviceId=bus1;SharedAccessKey=CXERs+jPxRuHSOZtW3TVtCplf3CkxuClCL/cdduMRVc=;ModuleId=VehicleTelemetry"; //Environment.GetEnvironmentVariable("EdgeHubConnectionString");

           
            Init().Wait();

            // Wait until the app unloads or is cancelled
            var cts = new CancellationTokenSource();
            AssemblyLoadContext.Default.Unloading += (ctx) => cts.Cancel();
            Console.CancelKeyPress += (sender, cpe) => cts.Cancel();
            WhenCancelled(cts.Token).Wait();
        }

        /// <summary>
        /// Handles cleanup operations when app is cancelled or unloads
        /// </summary>
        public static Task WhenCancelled(CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            cancellationToken.Register(s => ((TaskCompletionSource<bool>)s).SetResult(true), tcs);
            return tcs.Task;
        }

      
        
        /// <summary>
        /// Initializes the ModuleClient and sets up the callback to receive
        /// messages containing temperature information
        /// </summary>
        static async Task Init()
        {
          
            MqttTransportSettings mqttSetting = new MqttTransportSettings(TransportType.Mqtt_Tcp_Only);
            ITransportSettings[] settings = { mqttSetting };

            // Open a connection to the Edge runtime
            ModuleClient ioTHubModuleClient = await ModuleClient.CreateFromEnvironmentAsync(settings);
            await ioTHubModuleClient.OpenAsync();
            Console.WriteLine("IoT Hub module client initialized.");

            // Register callback to be called when a message is received by the module
            await ioTHubModuleClient.SetInputMessageHandlerAsync("input1", PipeMessage, ioTHubModuleClient);

            var moduleTwin = await ioTHubModuleClient.GetTwinAsync();
            var moduleTwinCollection = moduleTwin.Properties.Desired;
            if (moduleTwinCollection["VIN"] != null)
            {
                // TODO: 5 - Set the vin to the value in the module's twin
                vin = moduleTwinCollection["VIN"];
            }
            if (moduleTwinCollection["Borough"] != null)
            {
                // TODO: 6 - Set the borough to the value in the module's twin
                borough = moduleTwinCollection["Borough"];
            }

            // Attach callback for Twin desired properties updates
            await ioTHubModuleClient.SetDesiredPropertyUpdateCallbackAsync(onDesiredPropertiesUpdate, null);

            await GenerateMessage(ioTHubModuleClient);
        }

        static Task onDesiredPropertiesUpdate(TwinCollection desiredProperties, object userContext)
        {
            try
            {
                Console.WriteLine("Desired property change:");
                Console.WriteLine(JsonConvert.SerializeObject(desiredProperties));

                if (desiredProperties["VIN"] != null)
                {
                    vin = desiredProperties["VIN"];
                }
                if (desiredProperties["Borough"] != null)
                {
                    borough = desiredProperties["Borough"];
                }

            }
            catch (AggregateException ex)
            {
                foreach (Exception exception in ex.InnerExceptions)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error when receiving desired property: {0}", exception);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error when receiving desired property: {0}", ex.Message);
            }
            return Task.CompletedTask;
        }

         private static async Task GenerateMessage(ModuleClient ioTHubModuleClient)
        {
            string outputName = "output1";
            while (true)
            {
                try
                {
                    var info = new CarEvent() {
                        vin = vin,
                        outsideTemperature = GetOutsideTemp(borough),
                        engineTemperature  = GetEngineTemp(borough),
                        speed = GetSpeed(borough), 
                        fuel = random.Next(0,40),
                        engineoil = GetOil(borough),
                        tirepressure = GetTirePressure(borough),
                        odometer = random.Next (0,200000),
                        accelerator_pedal_position = random.Next (0,100),
                        parking_brake_status = GetRandomBoolean(),
                        headlamp_status = GetRandomBoolean(),
                        brake_pedal_status = GetRandomBoolean(),
                        transmission_gear_position = GetGearPos(),
                        ignition_status = GetRandomBoolean(),
                        windshield_wiper_status = GetRandomBoolean(),
                        abs = GetRandomBoolean(),   
                        timestamp = DateTime.UtcNow
                    };
                    var serializedString = JsonConvert.SerializeObject(info);
                    Console.WriteLine($"{DateTime.Now} > Sending message: {serializedString}");
                    var message = new Message(Encoding.UTF8.GetBytes(serializedString));
                    message.ContentEncoding = "utf-8";
                    message.ContentType = "application/json";
                    // TODO: 7 - Have the ModuleClient send the event message asynchronously, using the specified output name
                    await ioTHubModuleClient.SendEventAsync(outputName, message);
                }
                catch (AggregateException ex)
                {
                    foreach (Exception exception in ex.InnerExceptions)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error in sample: {0}", exception);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error in sample: {0}", ex.Message);
                }

                await Task.Delay(200);
            }
        }
        
        /// <summary>
        /// This method is called whenever the module is sent a message from the EdgeHub. 
        /// It just pipe the messages without any change.
        /// It prints all the incoming messages.
        /// </summary>
        static async Task<MessageResponse> PipeMessage(Message message, object userContext)
        {
            int counterValue = Interlocked.Increment(ref counter);

            var moduleClient = userContext as ModuleClient;
            if (moduleClient == null)
            {
                throw new InvalidOperationException("UserContext doesn't contain " + "expected values");
            }

            byte[] messageBytes = message.GetBytes();
            string messageString = Encoding.UTF8.GetString(messageBytes);
            Console.WriteLine($"Received message: {counterValue}, Body: [{messageString}]");

            if (!string.IsNullOrEmpty(messageString))
            {
                var pipeMessage = new Message(messageBytes);
                foreach (var prop in message.Properties)
                {
                    pipeMessage.Properties.Add(prop.Key, prop.Value);
                }
                await moduleClient.SendEventAsync("output1", pipeMessage);
                Console.WriteLine("Received message sent");
            }
            return MessageResponse.Completed;
        }

        static int GetSpeed(string borough)
        {
            if (borough.ToLower() == "brooklyn")
            {
                return GetRandomWeightedNumber(100, 0, highSpeedProbabilityPower);
            }
            return GetRandomWeightedNumber(100, 0, lowSpeedProbabilityPower);
        }

        static int GetOil(string borough)
        {
            if (borough.ToLower() == "manhattan")
            {
                return GetRandomWeightedNumber(50, 0, lowOilProbabilityPower);
            }
            return GetRandomWeightedNumber(50, 0, highOilProbabilityPower);
        }

        static int GetTirePressure(string borough)
        {
            if (borough.ToLower() == "manhattan")
            {
                return GetRandomWeightedNumber(50, 0, lowTirePressureProbabilityPower);
            }
            return GetRandomWeightedNumber(50, 0, highTirePressureProbabilityPower);
        }
        static int GetEngineTemp(string borough)
        {
            if (borough.ToLower() == "manhattan")
            {
                return GetRandomWeightedNumber(500, 0, highEngineTempProbabilityPower);
            }
            return GetRandomWeightedNumber(500, 0, lowEngineTempProbabilityPower);
        }
        static int GetOutsideTemp(string borough)
        {
            if (borough.ToLower() == "manhattan")
            {
                return GetRandomWeightedNumber(100, 0, lowOutsideTempProbabilityPower);
            }
            return GetRandomWeightedNumber(100, 0, highOutsideTempProbabilityPower);
        }
        private static int GetRandomWeightedNumber(int max, int min, double probabilityPower)
        {
            var randomizer = new Random();
            var randomDouble = randomizer.NextDouble();

            var result = Math.Floor(min + (max + 1 - min) * (Math.Pow(randomDouble, probabilityPower)));
            return (int)result;
        }
        static string GetGearPos()
        {
            List<string> list = new List<string>() { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eight"};
            int l = list.Count;
            Random r = new Random();
            int num = r.Next(l);
            return list[num];
        }
        static bool GetRandomBoolean()
        {
            return new Random().Next(100) % 2 == 0;
        }
    }
}

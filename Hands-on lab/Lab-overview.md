## Overview

The IoT and the Smart City hands-on lab is an exercise that will challenge you to implement an end-to-end scenario using a supplied sample that is based on IoT Hub, IoT Edge devices, Cosmos DB, Time Series Insights, Service Bus, and related Azure services. The hands-on lab can be implemented on your own, but it is highly recommended to pair up with other members at the lab to model a real-world experience and to allow each member to share their expertise for the overall solution.

## Solution architecture

![The Solution Architecture diagram is described in the text following the diagram.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image2.png 'Solution Architecture diagram')

The solution begins with an **IoT Edge Device** that would be installed on each city bus, which is responsible for reading the vehicle telemetry from the bus, such as speed, fuel level, oil level, engine temperature, etc., generated by **custom C\# module**. A **Stream Analytics module** is loaded on the IoT Edge device to filter the vehicle telemetry data so that only anomalies are sent to **IoT Hub**, all data is also stored locally on the device in the **Edge Storage Module**. The Edge Storage module is configured to upload data to Azure Blob Storage when adequate connectivity is achieved. A GPS IoT device is separately added to the bus to periodically send location and speed data to IoT Hub.

An IoT device is added to various traffic lights to send timing and voltage telemetry. It is registered as a device in IoT Hub, including properties such as its longitude and latitude and serial number. It can receive cloud-to-device messages through IoT Hub, allowing upstream services to send updates like adjusting the timing of its lights. The bus and traffic light devices are simulated using the IoT Remote Monitoring solution device simulator.

The Azure IoT Hub is configured with multiple consumer groups. This allows multiple downstream services to simultaneously read the incoming data.  **Time Series Insights** instance and an Azure Function microservice will read the incoming data. Time Series Insights is used to store the raw time series data and provides advanced filtering, custom ad-hoc queries, and visualizations that can overlay data from several classes of IoT devices. A second input into Time Series Insights provides the path for non-critical vehicle telemetry to be included from BLOB Storage.

An **Azure Function** using a separate consumer group routes filtered bus engine-related critical messages to a **Service Bus Queue**, where another **Azure Function** is triggered and outputs the critical alerts to a new collection in Cosmos DB.

The web app, which is part of the IoT Remote Monitoring solution, uses Device Twin information to display IoT devices on a map, provide real-time charts, and allows you to manage alert rules and device control messages. It is also used to provision new IoT devices and send manual cloud-to-device messages through IoT Hub.
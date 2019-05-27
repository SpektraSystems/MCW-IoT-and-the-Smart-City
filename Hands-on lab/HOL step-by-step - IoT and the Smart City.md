![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png 'Microsoft Cloud Workshops')

<div class="MCWHeader1">
IoT and the Smart City
</div>

<div class="MCWHeader2">
Hands-on lab step-by-step
</div>

<div class="MCWHeader3">
June 2019
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only, and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third-party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2019 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx are trademarks of the Microsoft group of companies. All other trademarks are the property of their respective owners.

**Contents**

<!-- TOC -->

- [IoT and the Smart City hands-on lab step-by-step](#iot-and-the-smart-city-hands-on-lab-step-by-step)
  - [Abstract and learning objectives](#abstract-and-learning-objectives)
  - [Overview](#overview)
  - [Solution architecture](#solution-architecture)
  - [Requirements](#requirements)
  - [Exercise 1: Set up IoT Remote Monitoring solution environment](#exercise-1-set-up-iot-remote-monitoring-solution-environment)
    - [Help references](#help-references)
    - [Task 1: Provision the Remote Monitoring Solution](#task-1-provision-the-remote-monitoring-solution)
    - [Task 2: Stop running device simulation in the Remote Monitoring Solution](#task-2-stop-running-device-simulation-in-the-remote-monitoring-solution)
  - [Exercise 2: Provision additional Azure services](#exercise-2-provision-additional-azure-services)
    - [Help references](#help-references-1)
    - [Task 1: Create Service Bus queue](#task-1-create-service-bus-queue)
    - [Task 2: Create the Critical Alerts collection in Cosmos Db](#task-2-create-the-critical-alerts-collection-in-cosmos-db)
    - [Task 3: Review the consumer groups in the IoT Hub](#task-3-review-the-consumer-groups-in-the-iot-hub)
    - [Task 4: Review the Azure Time Series Insights Instance](#task-4-review-the-azure-time-series-insights-instance)
    - [Task 5: Provision Azure Container Registry](#task-5-provision-azure-container-registry)
  - [Exercise 3: Create bus and traffic light simulated devices, and add alerts and filters](#exercise-3-create-bus-and-traffic-light-simulated-devices-and-add-alerts-and-filters)
    - [Help references](#help-references-2)
    - [Task 1: Configure the SimulationAgent and WebService projects to run locally](#task-1-configure-the-simulationagent-and-webservice-projects-to-run-locally)
    - [Task 2: Finish configuring the simulated IoT device models and scripts](#task-2-finish-configuring-the-simulated-iot-device-models-and-scripts)
    - [Task 3: Explore the remaining files to understand what is happening](#task-3-explore-the-remaining-files-to-understand-what-is-happening)
    - [Task 4: Configure and run the Storage Adapter project](#task-4-configure-and-run-the-storage-adapter-project)
    - [Task 5: Run the Simulator web app and create a new simulation](#task-5-run-the-simulator-web-app-and-create-a-new-simulation)
    - [Task 6: Run the device simulation agent locally](#task-6-run-the-device-simulation-agent-locally)
    - [Task 7: Create alerts and filters in the monitoring web app](#task-7-create-alerts-and-filters-in-the-monitoring-web-app)
    - [Task 8: Send jobs to IoT devices](#task-8-send-jobs-to-iot-devices)
  - [Exercise 4: Create IoT Edge device and custom modules](#exercise-4-create-iot-edge-device-and-custom-modules)
    - [Help references](#help-references-3)
    - [Task 1: Add a new IoT Edge device](#task-1-add-a-new-iot-edge-device)
    - [Task 2: Provision new Linux virtual machine to run as the IoT Edge Device](#task-2-provision-new-linux-virtual-machine-to-run-as-the-iot-edge-device)
    - [Task 3: Create and deploy the custom C\# IoT Edge module for vehicle telemetry](#task-3-create-and-deploy-the-custom-c-iot-edge-module-for-vehicle-telemetry)
    - [Task 4: Create the Azure Stream Analytics IoT Edge module](#task-4-create-the-azure-stream-analytics-iot-edge-module)
    - [Task 5: Deploy the custom modules to IoT Edge device](#task-5-deploy-the-custom-modules-to-iot-edge-device)
  - [Exercise 5: Create an Azure Function to add critical engine alerts to the Service Bus Queue](#exercise-5-create-an-azure-function-to-add-critical-engine-alerts-to-the-service-bus-queue)
    - [Task 1: Create a new Function App](#task-1-create-a-new-function-app)
    - [Task 2: Add new Function to process messages received by the IoT Hub](#task-2-add-new-function-to-process-messages-received-by-the-iot-hub)
  - [Exercise 6: Run a console app to view critical engine alerts from the Service Bus Queue](#exercise-6-run-a-console-app-to-view-critical-engine-alerts-from-the-service-bus-queue)
    - [Help references](#help-references-5)
    - [Task 1: Make sure the Service Bus Queue is receiving messages](#task-1-make-sure-the-service-bus-queue-is-receiving-messages)
    - [Task 2: Configure and execute the ReadEngineAlerts solution in Visual Studio 2017](#task-2-configure-and-execute-the-readenginealerts-solution-in-visual-studio-2017)
  - [Exercise 7: Create an Azure Function to ingest critical engine alerts and store them in Cosmos DB](#exercise-7-create-an-azure-function-to-ingest-critical-engine-alerts-and-store-them-in-cosmos-db)
    - [Help references](#help-references-5)
    - [Task 1: Create a new Function](#task-1-create-a-new-function)
    - [Task 2: Add an Azure Cosmos DB output to the critical-alerts collection](#task-2-add-an-azure-cosmos-db-output-to-the-critical-alerts-collection)
    - [Task 3: Modify the function code](#task-3-modify-the-function-code)
    - [Task 4: View data stored by the function in Azure Cosmos DB](#task-4-view-data-stored-by-the-function-in-azure-cosmos-db)
  - [Exercise 8: View critical engine alerts in the IoT Remote Monitoring web interface](#exercise-8-view-critical-engine-alerts-in-the-iot-remote-monitoring-web-interface)
    - [Task 1: View the bus data coming from IoT Edge](#task-1-view-the-bus-data-coming-from-iot-edge)
    - [Task 2: Define new alert rules for buses](#task-2-define-new-alert-rules-for-buses)
  - [Exercise 9: Add a tag to IoT Edge Device Twin](#exercise-9-add-a-tag-to-iot-edge-device-twin)
    - [Task 1: Create the tag update job](#task-1-create-the-tag-update-job)
    - [Task 2: Verify tag update in the device twin](#task-2-verify-tag-update-in-the-device-twin)
    - [Task 3: Create new IoT Edge device group](#task-3-create-new-iot-edge-device-group)
  - [Exercise 10: View all data in Azure Time Series Insights](#exercise-10-view-all-data-in-azure-time-series-insights)
    - [Help references](#help-references-6)
    - [Task 1: Add your account as a Contributor to the Data Access Policies](#task-1-add-your-account-as-a-contributor-to-the-data-access-policies)
    - [Task 2: Go to the Time Series Insights environment and use the data explorer](#task-2-go-to-the-time-series-insights-environment-and-use-the-data-explorer)
    - [Task 3: View the simulated and IoT Edge bus data side-by-side](#task-3-view-the-simulated-and-iot-edge-bus-data-side-by-side)
    - [Task 4: Use Perspective View to create a simultaneous view of up to four unique queries](#task-4-use-perspective-view-to-create-a-simultaneous-view-of-up-to-four-unique-queries)
  - [After the hands-on lab](#after-the-hands-on-lab)
    - [Task 1: Deprovision the accelerator through the website](#task-1-deprovision-the-accelerator-through-the-website)
    - [Task 2: Delete the Resource group in which you placed your Azure resources](#task-2-delete-the-resource-group-in-which-you-placed-your-azure-resources)

<!-- /TOC -->

# IoT and the Smart City hands-on lab step-by-step

## Abstract and learning objectives

In this hands-on-lab, you will build an end-to-end smart city solution. We will begin with deploying the Azure IoT Remote Monitoring Accelerator. This accelerator is meant to serve as an example of the recommendations set forth in the [Azure IoT Reference Architecture](https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/iot/). This accelerator may also serve as a customizable foundation for any real-world Remote Monitoring IoT systems. It has been built with the flexibility to define telemetry schemas, device types, groups, rules, and more. The Remote Monitoring accelerator also supports both simulated and real IoT devices - including an IoT Edge devices. The Remote Monitoring Web application displays all IoT data with charts and alerts based on preconfigured rules for each type of IoT device. You will also use this custom web app to configure IoT devices and send control messages to them via the IoT Hub

In this lab, we will deploy an Edge Device with a custom built module along with an on-device analytics engine which intelligently filters vehicle telemetry data for anomalies and transmits only this subset of data to IoT Hub thus reducing noise and saving on bandwidth and its associated costs. The telemetry data will also be stored in Time Series Insights, and all critical data will also flow through an Azure Function that routes critical alerts to a Service Bus Queue for separate processing and storage. You will deploy and configure .

We will take a deep dive into the IoT Hub. The IoT Hub is responsible for managing IoT devices and facilitating two-way communication between those devices and Azure services.

At the end of this hands-on lab, you will be better able to build an end-to-end IoT solution that processes and analyzes data both in the field and in the cloud.

## Overview

The IoT and the Smart City hands-on lab is an exercise that will challenge you to implement an end-to-end scenario using a supplied sample that is based on IoT Hub, IoT Edge devices, Cosmos DB, Time Series Insights, Service Bus, and related Azure services. The hands-on lab can be implemented on your own, but it is highly recommended to pair up with other members at the lab to model a real-world experience and to allow each member to share their expertise for the overall solution.

## Solution architecture

![The Solution Architecture diagram is described in the text following the diagram.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image2.png 'Solution Architecture diagram')

The solution begins with an **IoT Edge Device** that would be installed on each city bus, which is responsible for reading the vehicle telemetry from the bus, such as speed, fuel level, oil level, engine temperature, etc., generated by **custom C\# module**. A **Stream Analytics module** is loaded on the IoT Edge device to filter the vehicle telemetry data so that only anomalies are sent to **IoT Hub**. A GPS IoT device is separately added to the bus to periodically send location and speed data to IoT Hub. An IoT device is added to various traffic lights to send maintenance-related telemetry, such as voltage readings and whether a light is no longer functional. It is registered as a device in IoT Hub, including properties such as its longitude and latitude and serial number. It can receive cloud-to-device messages through IoT Hub, allowing upstream services to send updates like the timing of its lights based on traffic congestion information. The GPS IoT and traffic light devices are simulated using the IoT Remote Monitoring solution device simulator. An additional consumer group is added to IoT Hub's messages/events endpoint, allowing a **Time Series Insights** instance and an EventProcessor running on a microservice to simultaneously read the incoming data. Time Series Insights is used to store the raw time series data and provides advanced filtering, custom ad-hoc queries, and visualizations that can overlay data from several classes of IoT devices. A custom endpoint is created in Azure IoT Hub that is used to route filtered bus engine-related critical messages to a **Service Bus Queue**. An **Azure Function** is triggered on items being added to the queue, and outputs the critical alerts to a new collection in Cosmos DB. The EventProcessor is used to process incoming messages from IoT Hub to extract GPS and traffic light data, and store the data and any triggered alerts in Cosmos DB. The web app, which is part of the IoT Remote Monitoring solution, connects to Cosmos DB and displays the IoT data on a map, provides real-time charts, and allows you to manage alert rules and device control messages. It is also used to provision new IoT devices and send manual cloud-to-device messages through IoT Hub.

## Requirements

- Microsoft Azure subscription (non-Microsoft subscription) where you are at least a co-administrator.

- **Global Administrator role** for Azure AD within your subscription.

- You have completed the steps in [Before the hands-on-lab setup guide](Before%20the%20HOL.md).

- Local machine or a virtual machine configured with (**complete the day before the lab!**):

  - Visual Studio Code version 1.19.2 or higher

    - <https://code.visualstudio.com/>

  - Azure IoT Edge extension for Visual Studio Code

    - <https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-edge>

  - C\# for Visual Studio Code (powered by OmniSharp) extension

    - <https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp>

  - Docker on the same computer that has Visual Studio Code (Community Edition (CE) is sufficient)

    - <https://docs.docker.com/engine/installation/>

  - .NET Core 2.0 SDK

    - <https://www.microsoft.com/net/core#windowscmd>

  - Visual Studio Community 2017 or greater, version 15.4 or higher

    - <https://www.visualstudio.com/vs/>

  - Azure development workload for Visual Studio 2017

    - <https://docs.microsoft.com/azure/azure-functions/functions-develop-vs#prerequisites>

  - .NET desktop development workload for Visual Studio 2017

  - ASP.NET and web development workload for Visual Studio 2017

  - Node.js (install using either the 32-bit or 64-bit Windows Installer (.msi) option)

    - <https://nodejs.org/en/download/>

  - Postman app

    - <https://www.getpostman.com/apps>

  - Bash client (such as Git Bash or Bash on Ubuntu for Windows)

    - Instructions for installing the Windows Subsystem for Linux for using Bash: <https://docs.microsoft.com/en-us/windows/wsl/install-win10>

## Exercise 1: Set up IoT Remote Monitoring solution environment

**Duration:** 30 Minutes

In this exercise, you will take advantage of the 'Remote Monitoring' Microsoft Azure IoT Solution Accelerator. This accelerator will provision the components required to implement the IoT Remote Monitoring solution. This includes an Azure Resource Group, IoT Hub, Azure Storage account, App Service for hosting the monitoring web application, Device Provisioning Services, Virtual Machine, and related components that host the Function Application microservices responsible for creating, capturing, and processing IoT device messages, and a Cosmos DB instance for storing reference, alert, and telemetry data.

### Help references

|                                                      |                                                                                |
| ---------------------------------------------------- | :----------------------------------------------------------------------------: |
| **Description**                                      |                                   **Links**                                    |
| Remote Monitoring solution accelerator for Azure IoT | <https://www.azureiotsolutions.com/Accelerators#description/remote-monitoring> |

### Task 1: Provision the Remote Monitoring Solution

1.  Open a new web browser tab, and access **https://www.azureiotsolutions.com**.

2.  Select the **User Icon** in the upper right corner, and sign in with your **Azure Credentials**.

    ![Sign in with your Azure credentials](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image175.png 'Sign in')

3.  In the **Deploy a Microsoft solution accelerator** section, select the **Remote Monitoring** solution.

    ![Select the Remote Monitoring Solution](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image176.png 'Remote Monitoring Solution')

4.  This will bring you to a description screen for the Remote Monitoring Accelerator. This screen provides details surrounding the benefits of the template, the documentation, github links, and the Azure Services that will be provisioned. Provisioning of these Azure Services is automated. Press the **Try Now** button to start the provisioning process.

5.  The first step in provisioning the accelerator is to provide a deployment name. Enter **iot-remote-monitoring**, select the desired Azure subscription, for Deployment Options, select **C# Microservices**, then select the Azure Location nearest you. Finally, press the **Create** button.

    ![Remote Monitoring accelerator provisioning](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image177.png 'Remote Monitoring Solution Provisioning')

6.  The second step to provisioning the accelerator requires no intervention on your part. A checklist of provisioning steps will be displayed and is updated in real-time as they are completed. Please wait until provisioning has completed.

    ![Provisioning Checklist](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image178.png 'Provisioning Checklist')

7.  Once completed, you will be shown a success screen with a link allowing you to view your installed solution accelerator.

    ![Provisioning Completed](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image179.png 'Provisioning Completed')

8.  Alternatively, you may access installed accelerators in your account by clicking the **My Solutions** link on the (Azure IoT Solution Accelerators website)[https://www.azureiotsolutions.com].

    ![Launching the Remote Monitoring Solution](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image180.png 'Launch Solution')

9.  Upon launching the Remote Monitoring accelerator, you may be prompted to consent to accessing the Azure Portal to view the resources provisioned. Simply check the **Consent on behalf of your organization** and press the **Accept** button.

    ![Consent Dialog](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image181.png 'Consent Dialog')

10. When the Remote Monitoring solution is loaded, it will bring you into the Dashboard view. A series of simulated devices are feeding the portal with live data that is displayed in maps, charts, and metrics.

    ![Remote Monitoring Dashboard](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image183.png 'Remote Monitoring Dashboard')

11. Make a note of the URL of your Remote Monitoring web application - you will be utilizing this throughout this lab.

12. In the Azure Portal, you are able to see a listing of the resources provisioned to support the Remote Monitoring Accelerator solution. Access the [Azure Portal](https://portal.azure.com) and log in with your Azure credentials.

13. View the resources provisioned by the accelerator by choosing **Resource Groups** in the left-hand menu, then selecting the resource group that you entered in step 5 of this exercise, **iot-remote-monitoring**.

    ![Remote Monitoring Solution Accelerator Resources](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image182.png 'Remote Monitoring Solution Accelerator Resources')

### Task 2: Stop running device simulation in the Remote Monitoring Solution

1.  Navigate to your Remote Monitoring web application by pasting the URL in a browser window.

2.  When the site loads, select the **gear** icon on the upper-right corner.

3.  Shift the **Flowing** switch to stop the current device simulation. We will replace the simulated devices with our own.

    ![In the Azure IoT Suite Remote Monitoring Preview window, the Settings (gear) icon is selected. Simulation Data is set to Stop.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image18.png 'Azure IoT Remote Monitoring window')

4.  After stopping the simulation, take a moment to browse through the site. You will notice an interactive map as the centerpiece, provided by the Bing Maps and the Bing Maps API for Enterprise service that was provisioned as part of the solution. This will display each of your IoT devices that have location information.

    a. To the left of the map is a count of the devices, as well as the number of alarms and warnings that have been triggered based on preconfigured rules. We will add custom rules later on.

    b. Directly to the right of the map is a list of system alarms for the displayed devices.

    c. Beneath the map is a flowing line chart that displays telemetry data for selected devices and data points.

    d. To the right of the chart is a list of system KPIs (key performance indicators) that shows the number of alarms by device type and whether that number is increasing or decreasing.

    ![Screenshot of the Azure IoT Suite Remote Monitoring Preview window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image183.png 'Azure IoT Suite Remote Monitoring Preview window')

## Exercise 2: Provision additional Azure services

**Duration:** 45 minutes

Explore the components automatically provisioned by the Remote Monitoring Accelerator the previous exercise. Use the Azure portal to create services that will be used by the overall IoT solution environment. First, you will create an additional consumer group on the default messages/events IoT Hub endpoint. This will allow us to add more readers that can read the massive amounts of incoming IoT data being ingested by IoT Hub. This will help prevent conflicts from multiple readers attempting to modify the checkpoints and offsets of the partitions holding the messages. Next, you will add a custom endpoint and route to IoT Hub specifically for engine alerts arriving from your IoT Edge device that you will create later. Finally, you will provision a new Azure Time Series Insights instance to collect, filter, and display all-time series data flowing in from your simulated IoT devices as well as your IoT Edge device.

### Help references

|                                                         |                                                                                           |
| ------------------------------------------------------- | :---------------------------------------------------------------------------------------: |
| **Description**                                         |                                         **Links**                                         |
| Remote Monitoring preconfigured solution with Azure IoT |              https://github.com/Azure/azure-iot-pcs-remote-monitoring-dotnet              |
| What is Azure Time Series Insights?                     | https://docs.microsoft.com/en-us/azure/time-series-insights/time-series-insights-overview |

### Task 1: Create Service Bus queue

In this task, you will provision a new Service Bus queue that will be used for routing special bus engine-related critical alerts. Afterward, you will create a custom endpoint on your IoT Hub service that will be used to route filtered messages to this queue.

1.  Using a new tab or instance of your browser navigate to the **Azure Management** portal, <http://portal.azure.com>.

2.  Select **+ Create a Resource**, then type **service bus** into the search box on top. Select **Service Bus** from the results.

    ![In the Azure Portal, in the New blade, the search field is set to Service Bus.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image20.png 'Azure Portal')

3.  Select the **Create** button on the Service Bus overview blade.

4.  On the Create namespace blade, specify the following configuration options:

    a. **Name**: Unique value for the namespace name (ensure the green check mark appears).

    b. Select the **Standard** pricing tier.

    c. Specify your new **Resource Group**, ensuring it's the same one in which the accelerator components have been created.

    d. Select the same **Location** as your Resource Group and other services.

    ![The Create Namespace blade displays with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image21.png 'Create Namespace blade')

5.  Select **Create**.

6.  Navigate to the new **resource** after it has been created.

7.  On the overview blade of your Service Bus, select **+ Queue** to create a new queue.

    ![In the top menu of the iotlab-bus blade, + Queue is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image22.png 'iotlab-bus blade')

8.  On the **Create queue** blade, specify the following configuration options:

    a. **Name**: alert-q

    b. **Max queue size**: 1 GB

    c. Leave the remaining values at their defaults. It is important to note that you must **not** enable duplicate detection or sessions on queues that will be used as custom IoT Hub service endpoints. These settings will cause unexpected results and failures if applied.

    ![The Create queue blade displays with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image23.png 'Create queue blade')

9.  Select **Create**.

### Task 2: Create the Critical Alerts container in Cosmos Db

1.  Open your Azure Cosmos DB account by opening your resource group, and then selecting the Azure Cosmos DB account name. Select **Data Explorer** from the left-hand menu.

    ![Data Explorer is selected in the Azure Cosmos DB account blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image124.png 'Azure Cosmos DB account blade')

2.  There are currently two databases and two containers:

    a. **Database**: pcs-storage

    - **Container**: pcs-storage

      - **Description**: contains configuration data for the IoT Remote Monitoring solution.

    b. **Database**: pcs-iothub-stream

    - **Container**: alarms

      - **Description**: This is the container that holds all IoTHub messages that the remote monitoring solution receives

3.  Select **New Container**.

    ![In the Azure Cosmos DB account blade, the New Container button is selected. ](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image125.png 'Azure Cosmos DB new container blade')

4.  In the Add Collection form, specify the following:

    a. **Database Id**: pcs-iothub-stream

    b. **Container Id**: critical-alerts

    c. **Partition key**: /vin

    d. **Throughput**: 1000

    ![Fields in the Add Container blade display with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image126.png 'Add Container blade')

5.  Select **OK**.

### Task 3: Review the consumer groups in the IoT Hub

In this task, you will review the consumer groups that were added to the default messages/events IoT Hub endpoint, for other Azure resources to use. A consumer group can have a single reader and keeps track of items that have already been read, and what still remains to be read. Define a consumer group for each subscriber of IoT Hub event data.

1.  Using a new tab or instance of your browser navigate to the **Azure Management** portal, <http://portal.azure.com>.

2.  Browse to the **Resource Group** that was automatically created in the previous exercise. You can find your resource groups by selecting Resource groups in the left-hand side menu on the portal.

3.  Locate your **IoT Hub** within the resource group. Its name will start with "iothub-", followed by randomly generated characters.

    ![In the Azure Portal, Resource group blade, under Name, IoT Hub is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image24.png 'Azure Portal, Resource group blade')

4.  In the left-hand menu, select the **Built-in endpoints** item, this will bring up the **Events** endpoint information and consumer groups.

    ![IoT Hub Consumer Groups](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image221.png 'IoT Consumer Groups')

5.  Create a new consumer group by typing **queuefuncconsumergroup** into a Consumer Groups text box, we will use this consumer group later on in this lab.

![IoT Hub Create Consumer Group](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image222.png 'IoT Hub Create Consumer Group')

### Task 4: Review the Azure Time Series Insights instance

Azure Time Series Insights is the first fully managed time series database on the Azure platform. It was developed primarily with high volume IoT data in mind, where having a single location in which you can quickly view this information and derive insights on it is typically no small feat. Although the IoT Remote Monitoring solution you provisioned stores its simulated device data in Cosmos DB, you will be able to ingest that same data into Time Series Insights, along with data generated by your IoT Edge device. This is because all data flows through IoT Hub as the initial point of ingress. You have a time series consumer group on the Events endpoint specifically for Time Series Insights to be able to simultaneously read and store the same data that will land in Cosmos DB, as well as the added IoT Edge data. After reviewing the Time Series Insights instance, you will see how it's configured to use the IoT Hub consumer group as an input.

1.  Using a new tab or instance of your browser navigate to the **Azure Management** portal, <http://portal.azure.com>.

2.  Select the resource group that you created when deploying the Remote Monitoring Accelerator. In the list of resources, select the item with the type **Time Series Insights environment**.
    ![Time Series Insights environment resource.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image184.png 'Time Series Insights environment')

3.  Select **Event Sources** from the left-hand menu.

4.  View the IoT Hub Event Source.

    ![Event Sources is selected under Environment Toplogy, and the Add button is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image185.png 'Event Sources blade')

### Task 5: Provision Azure Container Registry

IoT Edge devices use one or more modules to perform a series of actions locally on the device before sending data up to the cloud. Modules include custom modules written in a language like C\#, Azure Stream Analytics that runs on the device, Azure Machine Learning, and Azure Functions. Each of these modules is hosted within a Docker container. We will be creating two modules for the IoT Edge device: a custom C\# module, and an Azure Stream Analytics module. In both cases, you will be creating a container image from the files. The images are then pushed to a registry that stores and manages them. The final step is to deploy the images from the registry onto your IoT Edge devices. Two popular Docker registry services available in the cloud are Azure Container Registry and Docker Hub. We will be using Azure Container Registry to manage and deploy the IoT Edge modules.

1.  Using a new tab or instance of your browser navigate to the **Azure Management** portal, <http://portal.azure.com>.

2.  Select **+ Create a resource**, then type **container registry** into the search box on top. Select **Container Registry** from the results.

    ![The search field in the New blade displays Azure Container Registry.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image36.png 'New blade')

3.  Select the **Create** button on the **Container Registry overview** blade.

4.  On the **Create container registry** blade, specify the following configuration options:

    a. **Name**: Unique value for the registry name (ensure the green check mark appears).

    b. Specify your **Resource Group**, ensuring it's the same one in which your new components have been created.

    c. Select the same **Location** as your Resource Group and other services.

    d. **Enable** the Admin user.

    e. Select the **Basic** SKU.

    ![The Create container registry blade displays with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image37.png 'Create container registry blade')

5.  Select **Create**.

6.  After provisioning is complete, go to your new Container Registry resource and select **Access keys** from the left-hand menu.

7.  Copy the **Login server**, **Username**, and **Password** values and save them for later.

    ![In the Container registry blade, under Settings, Access keys is selected. The copy buttons for Login server, Username, and password are all called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image38.png 'Container registry blade')

## Exercise 3: Create bus and traffic light simulated devices, and add alerts and filters

**Duration:** 60 minutes

The IoT Remote Monitoring solution allows you to provision and collect telemetry from both simulated and real devices. As part of the process, telemetry schema information is applied to the device's twin through its reported properties. The properties are read as the microservice that's executing the EventProcessor processes incoming messages from IoT Hub. The telemetry metadata is used to write the data to Cosmos DB, then used again later by the web app to extract and display the data on the chart and map. The metadata is also used to define cloud-to-device messages and actions that can be performed on the device. The web app uses this information to send control messages to the devices. This metadata is added to simulated and non-simulated devices alike.

In this exercise, you will define metadata for new device types that will be provisioned, and whose telemetry will be simulated by the solution. Each new device type will have a state script to generate telemetry that changes the device's state, whether speed, location, voltage, or other data that relates to the device. In addition, you will define cloud-to-device messages and actions for the new device types. Then, you will create and run a new simulation locally, using a Visual Studio solution. Finally, you will create new alerts and filters through the web app interface.

We have created the following files for you, located within the device-simulation project (/azure-iot-pcs-remote-monitoring-dotnet/device-simulation/Services/data/devicemodels):

- Device models:

  - bus-01.json

  - bus-02.json

  - trafficlight-01.json

  - trafficlight-02.json

- Scripts (/scripts subfolder):

  - bus-01-state.js

  - bus-02-state.js

  - trafficlight-01-state.js

  - trafficlight-02-state.js

  - DecreaseTiming-method.js

  - IncreaseTiming-method.js

You will need to finish configuring these files for the simulator.

### Help references

|                                             |                                                                                                   |
| ------------------------------------------- | :-----------------------------------------------------------------------------------------------: |
| **Description**                             |                                             **Links**                                             |
| IoT Remote Monitoring device models specs   |              <https://github.com/Azure/device-simulation-dotnet/wiki/Device-Models>               |
| Creating and managing simulations           |   <https://github.com/Azure/device-simulation-dotnet/wiki/%5BAPI-Specifications%5D-Simulations>   |
| Use rules to detect issues                  |      <https://docs.microsoft.com/en-us/azure/iot-suite/iot-suite-remote-monitoring-automate>      |
| Customize the device simulator microservice |        <https://docs.microsoft.com/en-us/azure/iot-suite/iot-suite-remote-monitoring-test>        |
| IoT Remote Monitoring solution architecture | <https://docs.microsoft.com/en-us/azure/iot-suite/iot-suite-remote-monitoring-sample-walkthrough> |

### Task 1: Configure the SimulationAgent and WebService projects to run locally

In this task, you will open the device-simulation solution in Visual Studio 2019 and configure the SimulationAgent and WebService projects to run locally.

1.  Browse to the device-simulation solution in the following location: \[your-Lab-files-folder\]\\azure-iot-pcs-remote-monitoring-dotnet\\device-simulation.

2.  Open **device-simulation.sln**.

    ![File Explorer displays with the previous path and file called out.](media/device-simulation-folder-explorer.png 'File Explorer')

3.  Right-click the **SimulationAgent** project in the Solution Explorer, then select **Properties**.

    ![In Solution Explorer, SimulationAgent is selected, and its right-click menu displays with Properties selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image41.png 'Solution Explorer')

4.  Select **Application** from the left-hand menu. Expand the dropdown menu beneath "Target framework", then select **.NET Core 2.0**.

    ![The Assembly name and Target framework fields display.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image42.png 'Simulator fields')

5.  Select **Debug** from the left-hand menu. In the Environment variables section, add the PCS_IOTHUB_CONNSTRING variable, replacing the value with the IoT Hub connection string you copied earlier.

    ![On the SimulationAgent properties, Debug tab is selected, and in the Environment variables section, the value for PCS_IOTHUB_CONNSTRING is added.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image43.png 'SimulationAgent project debug properties')

6.  In the same Environment variables section, add the PCS_STORAGEADAPTER_WEBSERVICE_URL variable, replacing the value with **http://localhost:9022/v1**.

    ![On the SimulationAgent properties, Debug tab is selected, and in the Environment variables section, the value for PCS_STORAGEADAPTER_WEBSERVICE_URL is added.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image187.png 'SimulationAgent project debug properties')

7.  Save your changes to the file.

8.  Right-click the **WebService** project, go to **Properties**. Select **Application** from the left-hand menu. Expand the dropdown menu beneath "Target framework", then select **.NET Core 2.0**.

9.  Next, select **Debug** from the left-hand menu.

    a. Ensure the **Launch Browser** checkbox is checked and that its value is set to **http://localhost:9003/v1/status**.

    b. Add the **PCS_IOTHUB_CONNSTRING** environment variable with the same value you supplied for the SimulationAgent.

    c. Add another Environment variable named **PCS_STORAGEADAPTER_WEBSERVICE_URL** and set its value to **http://localhost:9022/v1**.

    d. Remaining on the **Debug** screen, in the **Web Server Settings** section, ensure the **App URL** property is set to **http://localhost:9003/**.

![On the WebService project properties, Debug tab is selected](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image190.png 'WebService project debug properties')

10. Save your changes to the file.

### Task 2: Finish configuring the simulated IoT device models and scripts

In this task, you will finish configuring the device models we have provided for you.

1.  With the device-simulation solution still open, use Solution Explorer to expand the **Services** project. Next, open **bus-01.json** located under **data\\devicemodels**.

    ![The following path is expanded in Solution Explorer: Services\Data\devicemodels. Under devicemodels, bus-o1.json is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image44.png 'Solution Explorer')

2.  Set the following Simulation.InitialState values. These are the parameters used at the start of the device simulation:

    a. **latitude**: 40.755086

    b. **longitude**: -73.984165

    c. **fuellevel**: 70.0

    d. **speed**: 30.0

    e. **vin**: Y3J9PV9TN36A4DUB9

    ![The previously defined vaues are circled in the JSON code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image45.png 'JSON code window')

3.  Set the following Properties:

    a. **Type**: Bus

    b. **Location**: Manhattan

    ![Properties_bus_manhattan](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image46.png)

4.  There are two Telemetry schemas set for this bus. The first one should send telemetry every 10 seconds, while the other one should have an interval of one minute. Complete the Telemetry values according to the following specifications:

    a. Telemetry \#1:

    - **MessageSchema.Fields**:

      - **latitude**: double

      - **longitude**: double

      - **speed**: double

      - **speed_unit**: text

      - **vin**: text

    b. Telemetry \#2:

    - MessageTemplate (use the MessageTemplate value of the first telemetry as a guide): Include the fuellevel and fuellevel_unit fields.

    - **MessageSchema.Fields**:

      - **fuellevel**: double

      - **fuellevel_unit**: text

![The previously defined telemetry values are circled in the JSON code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image47.png 'JSON code window')

5.  Save your changes.

6.  Open **bus-02.json**.

7.  Set the following Simulation.InitialState values. These are the parameters used at the start of the device simulation:

    a. **latitude**: 40.693935

    b. **longitude**: -73.952279

    c. **fuellevel**: 53.0

    d. **speed**: 42.0

    e. **vin**: 2K0H7PNZY0RSFQ033

    ![The previously defined values are circled in the JSON code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image48.png 'JSON Code Window')

8.  Set the following Properties:

    a. **Type**: Bus

    b. **Location**: Brooklyn

    ![The previously defined properties are circled in the JSON Code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image49.png 'JSON Code window')

9.  There are two Telemetry schemas set for this bus. The first one should send telemetry every 12 seconds, while the other one should have an interval of 55 seconds. Complete the Telemetry values according to the following specifications:

- Telemetry \#1:

  - MessageSchema.Fields:

    a. **latitude**: double

    b. **longitude**: double

    c. **speed**: double

    d. **speed_unit**: text

    d. **vin**: text

- Telemetry \#2:

  - MessageTemplate (use the MessageTemplate value of the first telemetry as a guide): Include the fuellevel and fuellevel_unit fields.

  - MessageSchema.Fields:

    a. **fuellevel**: double

    b. **fuellevel_unit**: text

  ![The previously defined telemetry values are circled in the JSON code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image50.png 'JSON code window')

10. Save your changes.

11. Open **trafficlight-01.json**.

12. Add the following **CloudToDeviceMethods**:

    - IncreaseTiming

      - **Type**: javascript

      - **Path**: IncreaseTiming-method.js

    - DecreaseTiming

      - **Type**: javascript

      - **Path**: DecreaseTiming-method.js

    ![The previously defined methods are circled in the JSON code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image51.png 'JSON Code Window')

13. Save your changes.

14. Open **trafficlight-02.json**.

15. Add the same **CloudToDeviceMethods** that you added to trafficlight-01.json.

16. Save your changes.

17. In Solution Explorer, expand the scripts subfolder (Services\\data\\devicemodels\\scripts), then open **bus-01-state.js**.

18. Scroll down to the **main** function and complete the following lines of code:

    a. Find TODO: 1 and complete the line of code underneath to set the state.speed value to a random double value with an average of 30, \~40%, a minimum value of 0 and a maximum of 80.

    b. Find TODO: 2 and complete the line of code underneath to set the state.fuellevel value to a random double value with an average of 70, \~25%, a minimum value of 2 and a maximum of 80.

    c. Your finished code should look like the following:

    ```javascript
    // 30 +/- 40%,  Min 0, Max 80
    // TODO: 1 - finish this line of code:
    state.speed = vary(30, 40, 0, 80);

    // 70 +/- 25%,  Min 2, Max 80
    // TODO: 2 - finish this line of code:
    state.fuellevel = vary(70, 25, 2, 80);
    ```

19. Save your changes.

20. Open **bus-02-state.js**.

21. Scroll down to the **main** function and complete the following lines of code:

    a. Find TODO: 3 and complete the line of code underneath to set the state.speed value to a random double value with an average of 42, \~50%, a minimum value of 0 and a maximum of 80.

    b. Find TODO: 4 and complete the line of code underneath to set the state.fuellevel value to a random double value with an average of 53, \~25%, a minimum value of 2 and a maximum of 80.

    c. Your finished code should look like the following:

    ```javascript
    // 42 +/- 50%,  Min 0, Max 80
    // TODO: 3 - finish this line of code:
    state.speed = vary(42, 50, 0, 80);

    // 53 +/- 25%,  Min 2, Max 80
    // TODO: 4 - finish this line of code:
    state.fuellevel = vary(53, 25, 2, 80);
    ```

22. Save your changes.

23. Open trafficlight-01-state.js and observe how it is altering values over time. You will see that it is varying the light state (red, green, yellow), as well as the voltage. If you look at trafficlight-02-state.js, you will notice that its voltage range is significantly higher than for the first traffic light. When we create an alert, this will most likely be the light that triggers it.

24. Open DecreaseTiming-method.js and see how it is used as an action method to reset the timing state of a traffic light by decreasing the timing 15 seconds at a time. This is executed by a cloud-to-device call from the monitoring web app.

### Task 3: Explore the remaining files to understand what is happening

Below is a table containing file paths and an explanation of what each does in the simulator. There are a few key things to point out so that you know how the Service SDK for Azure IoT Devices can be used to programmatically manage devices.

1.  With the device-simulation solution still open in Visual Studio, look at each of the following files and descriptions to understand how things work:

    - Visual Studio Project: Services
      - **File Path**: Devices.cs
      - **Description**: GetAsync method (line 102) accepts a Device Id and uses it to retrieve the device details from IoT Hub, using the Service SDK's RegistryManager. It will optionally retrieve the device twin which can be used to view the current twin properties and update their values. CreateAsync method (line 156) is used to provision a new IoT Device, using the RegistryManager. It also creates a new device twin containing the IsSimulated tag. This is how the IoT Monitor app can differentiate between simulated and physical devices.


    - Visual Studio Project: Services
        - **File Path**: DeviceClient.cs
        - **Description**: SendMessageAsync method (line 100) constructs a new Message object that it will send to IoT Hub. It includes the event message properties to include the message content type (JSON), and the schema name, as defined in the device model scripts you edited earlier. The microservice running the IoT Hub EventProcessor will look for these values before processing messages and saving them to Cosmos DB.

    - Visual Studio Project: SimulationAgent
        - **File Path**: Simulation\\DeviceActor.cs
        - **Description**: Each device is assigned an instance of the DeviceActor class. This class manages the following state machine flow (as shown within the MoveNext method).
            - Connect to IoT Hub.
            - Bootstrap the device to retrieve it, create if necessary, and update the device twin state.
            - Update the device state using the state scripts we created, in order to send telemetry.
            - Sends telemetry using the message template provided, as seen in the bus and traffic light device model scripts you edited earlier. Uses the DeviceClient class to send the message through the Device SDK for Azure IoT Devices.

    - Visual Studio Project: WebService
        - **File Path**: v1\\Controllers\\SimulationsController
        - **Description**: This web API controller contains REST methods that allow you to retrieve, insert, update, and delete device simulations. The simulation values are updated in Cosmos DB by way of the Simulations service (Services project -- Simulations.cs), which uses the running pcs-storage-adapter service to modify the values in Cosmos DB. We will be using this next.

### Task 4: Configure and run the Storage Adapter project

The Storage Adapter project (pcs-storage-adapter) is another microservice that constantly runs and provides REST-based endpoints to manage simple key/value data in Cosmos DB. It is used by several services, including the web service within the device-simulator project, as seen in the previous task. This needs to be configured, then executed to run before creating and running simulations on the new devices locally.

1.  Browse to the storage-adapter solution in the following location: \[your-Lab-files-folder\]\\azure-iot-pcs-remote-monitoring-dotnet\\storage-adapter.

2.  Open **pcs-storage-adapter.sln**.

    ![File Explorer is open to the the previously defined path, and the .sln file is selected.](media/storage-adapter-file-explorer.png 'File Explorer')

3.  Right-click the **WebService** project in the Solution Explorer, then select **Properties**.

    ![In Solution Explorer, WebService is selected, and on its right-click menu, Properties is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image53.png 'Solution Explorer')

4.  Select **Application** from the left-hand menu. Expand the dropdown menu beneath "Target framework", then select **.NET Core 2.0**.

    ![The Assembly name and Target framework fields display.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image54.png 'Simulator fields')

5.  Select **Debug** from the left-hand menu. In the Environment variables section, add the PCS_STORAGEADAPTER_DOCUMENTDB_CONNSTRING value, replacing "..." with the Cosmos DB connection string. To find your connection string, do the following:

    a. Open your Cosmos DB instance from within your lab's resource group.

    b. Select **Keys** from the left-hand menu.

    c. Copy the **Primary Connection String**.

    d. Paste the value in the PCS_STORAGEADAPTER_DOCUMENTDB_CONNSTRING environment variable value.

![In the Azure Cosmos DB account blade, under Settings, Keys is selected. On the Read-write keys tab, the copy button is selected for the Primary Connection String.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image55.png 'Azure Cosmos DB account blade')

![On the WebService tab, Debug is selected, and the Environment variables value is called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image56.png 'WebService tab')

6.  Remaining in your **Debug** screen:

    a. Ensure the **Launch Browser** checkmark is checked, and has the value **http://localhost:9022/v1/status**.

    b. In the **Web Server Settings** section, ensure the **App URL** is set to **http://localhost:9022/**.

    ![On the WebService tab, Debug is selected, and the Launch Browser and App Url settings are set.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image212.png 'WebService Properties Debug tab')

7.  Save your changes to the file.

8.  Right-click the **WebService** project once again, then select **Start new instance** under **Debug**.

    ![In Solution Explorer, WebService is selected, and from its right-click menu, Debug, and then Start new instance are selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image57.png 'Solution Explorer')

9.  The web service should launch in a new browser window at the following path: <http://localhost:9022/v1/status>. You should also see a status response on the page showing the service is OK.

    ![The status response of "OK: Alive and well" is highlighted in the Web service window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image58.png 'Web service window')

10. Leave the project running in debug mode for the duration of the lab.

### Task 5: Run the Simulator web app and create a new simulation

In this task, you will run the Simulator web app locally and send REST-based commands to it to delete the existing simulation and define a new one using only the devices we want to simulate for the lab, including the new device types.

1.  Switch back to the **device-simulation** solution in Visual Studio. Right-click the **WebService** project, then select **Start new instance** under **Debug**, to run a new instance of the web app.

    ![In Solution Explorer, WebService is selected, and from its right-click menu, Debug, and then Start new instance are selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image59.png 'Solution Explorer')

2.  This will launch a new browser window at the following path: <http://localhost:9003/v1/status>. You will likely see an output containing errors about the RateLimiting object reference being null. Ignore this error, as it does not impact the web service. You may need to tell the debugger in Visual Studio to continue running.

3.  Open **Postman**. You should have it installed from the lab's prerequisites. If not, refer to the link to install Postman found there.

4.  Enter http://localhost:9003/v1/simulations/1 into the URL field, making sure that the **GET** method is selected. Then select **Send**. You should see a JSON response with a status of 200 OK.

    ![In the Postman window, on the Retrieve IoT device simulation details tab, both Get and the previously defined URL are circled, and the Send button is selected. a JSON response displays below.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image60.png 'Postman window')

5.  The response will show that the simulation is disabled from when you set it to disabled through the IoT Remote Monitoring web interface earlier. It also lists the current device models configured for the simulation. We want to change this to use our new device models. First, we need to delete the current simulation.

6.  Select to add a new request. This time, select the **DELETE** method and enter <http://localhost:9003/v1/simulations/1 as the URL. Select **Send**. There will be no JSON response this time. Instead, make sure the returned status is 200 OK.

    ![In the Postman window, on the Delete an IoT device simulation tab, both Delete and the previously defined URL are circled, and the Send button is selected. Below, Status: 200 OK is called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image61.png 'Postman window')

7.  To verify, you can execute the first GET command. If the solution was deleted, you will see an exception that Resource simulations/1 was not found.

8.  Add a new request. Select the **POST** method and enter <http://localhost:9003/v1/simulations as the URL.

9.  Select **Headers** beneath the URL and add the following Key / Value pair:

    a. **Key**: Content-Type

    b. **Value**: application/json

    ![In the Postman window, both Post and the previously defined URL are circled. Below, the Headers tab is selected, and the Content-Type key with an applicaton/json value is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image62.png 'Postman window')

10. Select **Body**, select **raw**, then **JSON (application/json)** as the content type. Paste the following to create a new simulation with our new models, plus existing elevator models:

    ```
    {
        "Enabled": true,
            "DeviceModels": [
                {
                    "Id": "bus-01",
                    "Count": 1
                },
                {
                    "Id": "bus-02",
                    "Count": 1
                },
                {
                    "Id": "elevator-01",
                    "Count": 3
                },
                {
                    "Id": "elevator-02",
                    "Count": 2
                },
                {
                    "Id": "trafficlight-01",
                    "Count": 1
                },
                {
                    "Id": "trafficlight-02",
                    "Count": 1
                }
            ]
    }

    ```

    ![In the Postman window, on the Create a new IoT Hub tab, on the Body tab, raw is selected. JSON (application/json) is selected, and the JSON code as previously defined displays below.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image63.png 'Postman window')

11. Select **Send**. You should receive a response status of 200 OK, and output showing the new simulation information with your defined devices. The Enabled value should also be true.

    ![In the Postman window, Send is selected, Status: 200 OK displays, and in the Body, "Enabled"; True, is called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image64.png 'Postman window')

### Task 6: Run the device simulation agent locally

In this task, you will run the device simulation agent (SimulationAgent project) locally to run the simulation you just created. Because you created the new device elements locally, this is where you will run the simulation for the lab. To permanently have this run from the hosted Docker container, you would need to create a new Docker image, publish it to your own Docker Hub account, and either update the solution scripts to use the custom image and redeploy your solution to Azure, or ssh into the VM hosting the container and manually replace the image there. These steps are beyond the scope of the lab, but can be found in the [developer reference guide](https://github.com/Azure/azure-iot-pcs-remote-monitoring-dotnet/wiki/Developer-Reference-Guide).

Run the simulator and let it continue running in the background.

1.  Switch back to the **device-simulation** solution in Visual Studio. Right-click the **SimulationAgent** project, then select **Start new instance** under **Debug**, to run a new instance of the console app.

    ![In Solution Explorer, SimulationAgent is selected, and from its right-click menus, Debug and Start new instance are both selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image65.png 'Solution Explorer')

2.  This will launch a console window, displaying the logging data as the simulation is run.

    ![Screenshot of the Console window. ](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image66.png 'Console window')

3.  Allow this to continue running in the background for the remainder of the lab.

### Task 7: Create alerts and filters in the monitoring web app

The IoT Remote Monitoring web interface enables you to create filters that help group devices by type or other parameters. You can also create alerts that are fired when certain criteria are met, enabling you to see the alerts alongside your device data or on the map. In this task, you will create filters for your buses and traffic lights, then create an alert for traffic lights whose voltage exceed a predefined level.

1.  Navigate back to the monitoring web app. If you don't remember the path or have closed the previous browser session, the naming convention is **https://\[your solution name\].azurewebsites.net/dashboard**. You may need to refresh the browser window if it has been running for some time and is unresponsive.

2.  One of the first things you may notice is that there are new telemetry data points listed above the graph. You should also see new devices showing up on the map over New York City. In the screenshot below, the new fuel level telemetry option is selected, and data for the two new buses appear beneath. (Note: You may need to wait a few minutes with the simulator running in order for the New York data points to appear - zoom out the map to see them.)

    ![The Monitoring Web App dashboard displays with the previously described information.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image67.png 'Monitoring Web App dashboard')

    ![The Monitoring Web App dashboard displays with the previously described information.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image191.png 'Monitoring Web App dashboard')

3.  Create a new device group by selecting **Manage device groups** on the upper-right portion of the dashboard.

    ![Screenshot of the Manage filters icon.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image68.png 'Manage filters')

4.  Select **+ Create new device group**, then provide the following parameters in the form:

    a. **Name**: Buses

    b. **Field**: Properties.Reported.Type

    c. **Operator**: = Equals

    d. **Value**: Bus

    e. **Type**: Text

    ![Under Create Filter, fields are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image69.png 'Create Filter section')

5.  Select **Save**.

6.  Create another device group with the following parameters in the form:

    a. **Name**: Traffic Lights

    b. **Field**: Properties.Reported.Type

    c. **Operato**r: = Equals

    d. **Value**: Traffic Light

    e. **Type**: Text

7.  After creating both device groups, you may select them using the filter drop-down list to the left of the map. In the screenshot below, we have selected Traffic Lights. Notice that in the telemetry graph, it shows just the two traffic light devices. Also notice that one traffic light has consistently higher voltage than the other, as dictated by the traffic device model state script modified earlier. Now we'll create a new alert for traffic lights whose voltage is too high. **As of this writing the chart showing voltage data in the Accelerator dashboard is not functional, this is an older screenshot.**

    ![The Monitoring Web App dashboard displays with the previously described information.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image70.png 'Monitoring Web App dashboard')

8.  Select **Rules** in the left-hand menu.

9.  Change the filter to All devices so you can view the list of existing rules. Each one has a unique name and description, are marked with a severity level, and have filters and triggers to apply the rule to specific devices and act on certain criteria. Select **+ New rule** to create a new rule for the traffic lights.

    ![Under Rules and Actions, All devices and New rule are both selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image71.png 'Rules and Actions section')

10. Specify the following values in the New rule form:

    a. **Rule Name**: Voltage Too High

    b. **Description**: Traffic light voltage is higher than normal.

    c. **Device group**: Select your Traffic Lights group.

    d. **Calculation**: Select Instant.

    e. **Condition1**:

    - **Field**: voltage

    - **Operator**: \>=

    - **Value**: 74

    f. **Severity level**: Critical

    g. **Rule status**: Enabled

    ![Fields in the New rule section are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image72.png 'New rule section')

    ![Fields in the New rule section are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image192.png 'New rule section')

11. Select **Apply**. Notice that it shows 2 devices are affected by this rule.

12. Navigate back to the dashboard. It may take a few minutes for the alerts to start appearing. When you filter by Traffic Lights and zoom in on the map over New York, you will see both traffic lights pinned to the map. One with the critical alert. Also notice the alarm count on the left.

    ![The Monitoring Web App dashboard displays with the previously described information. The Alarm count is 23, and a traffic light alert is called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image73.png 'Monitoring Web App dashboard ')

13. Select the **traffic light** with the error indicator on the map. The device details will be displayed to the right, along with a list of the triggered alarms.

14. Select **Maintenance** on the left-hand menu.

15. Select the **Voltage Too High** alert. You will see a list of occurrences and devices that triggered the alarm. Using the menu on top, you can close or acknowledge alerts for each selected occurrence in the list.

    ![In the Maintenance section, two alerts for Voltage too high are selected. At the top, right, the Close and Acknowledge buttons are called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image74.png 'Maintenance section')

### Task 8: Send jobs to IoT devices

In this task, you will send a job to one of the traffic light devices, using the DecreaseTiming job defined in the scripts folder of the device-simulation project.

1.  Navigate back to the monitoring web app's dashboard.

2.  Select the **timing** telemetry option. Observe the current timing for the traffic lights. One should consistently be 90 (seconds), and the other 65.

    ![In the Telemetry section, timing (2) is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image75.png 'Telemetry section')

3.  Navigate to **Device Explorer** using the left-hand menu.

4.  Check the box next to **Simulated.Trafficlight-01.0** (or whichever the traffic light \#1 is named in your list).

5.  Select **jobs** in the top menu.

6.  Select **Run Method**.

7.  In the **Method Name**, select **DecreaseTiming** and provide a name.

8.  Select **Apply**. You may view the job status in the maintenance page, if desired.

    ![Callouts point to the previously mentioned settings and buttons in the Devices section.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image76.png 'Devices section')

9.  Navigate back to the dashboard and view the **timing** telemetry once again. This time, you should notice that the traffic light timing for traffic light \#1 decreased from 90 seconds to 75. (You may need to wait a couple of minutes to see the effect in the chart)

    ![In the Telemetry section, the decrease is circled on the graph.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image77.png 'Telemetry section')

## Exercise 4: Create IoT Edge device and custom modules

**Duration:** 60 minutes

Azure IoT Edge devices can run on in locations where there is little to no internet connectivity, yet they allow you to run powerful modules locally, enabling you to apply your business logic in place. This is especially powerful when coupled with sensors that generate a lot of data, and you only want to send the most important data to the cloud.

In this scenario, IoT Edge devices will be installed on city buses. You will create a Stream Analytics module to filter the vehicle telemetry data from simulated sensors located within a custom module that you will also build and deploy. When the Stream Analytics module finds behavior consistent with aggressive driving or impending engine failure, the data will be sent to Azure via IoT Hub. The obvious benefit to this is that the massive amount of data can be analyzed locally, only the important data is sent over a slow, unreliable, or expensive cellular data connection.

### Help references

|                                                                       |                                                                                 |
| --------------------------------------------------------------------- | :-----------------------------------------------------------------------------: |
| **Description**                                                       |                                    **Links**                                    |
| What is Azure IoT Edge?                                               |      <https://docs.microsoft.com/en-us/azure/iot-edge/how-iot-edge-works>       |
| Understand the requirements and tools for developing IoT Edge modules |      <https://docs.microsoft.com/en-us/azure/iot-edge/module-development>       |
| Develop and deploy a C\# IoT Edge module to your simulated device     |    <https://docs.microsoft.com/en-us/azure/iot-edge/tutorial-csharp-module>     |
| Azure Stream Analytics on IoT Edge                                    | <https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-edge> |

### Task 1: Add a new IoT Edge device

1.  Navigate to the Azure Management portal, <http://portal.azure.com>.

2.  Open **IoT Hub** in your solution's resource group.

3.  Select **IoT Edge** from the left-hand menu, then select **+ Add to IoT Edge Device**.

    ![The Add IoT Edge Device button is selected in the IoT Hub blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image78.png 'IoT Hub blade')

4.  On the Add Device blade, specify the following configuration options:

    a. **Device ID**: bus1

    b. Make sure the Symmetric Key **Authentication Type** is selected, and **Auto Generate Keys** is checked.

    c. **Connect device to IoT Hub** should be Enabled.

    ![In the Add Device blade, fields are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image79.png 'Add Device blade')

5.  Select **Save**.

6.  Select your new IoT Edge device from the list of devices.

7.  Copy the value for **Connection string--primary key** and save it. This will be used to configure the IoT Edge runtime.

    ![In the Device Details blade, the copy button for the Connection string - primary key is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image80.png 'Device Details blade')

8.  Open the device twin properties by pressing the **Device twin** button.

    ![In the Device Details blade, press the Device twin button.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image213.png 'Device Details blade')

9.  Set the device twin desired properties to the following, then press **Save**:

    ```javascript
      "Protocol": "MQTT",
      "SupportedMethods": "",
      "Telemetry": {
        "bus-edge;v1": {
          "MessageSchema": {
            "Name": "bus-edge;v1",
            "Format": "JSON",
            "Fields": {
              "abs": "Integer",
              "accelerator_pedal_position": "Integer",
              "agressiveDriving": "Integer",
              "averageEngineTemperature": "Double",
              "averageSpeed": "Double",
              "brake_pedal_status": "Integer",
              "engineoil": "Integer",
              "enginetempanomaly": "Integer",
              "engineTemperature": "Integer",
              "fuel": "Integer",
              "headlamp_status": "Integer",
              "ignitionStatus": "Integer",
              "iothubConnectionModuleId": "Text",
              "odometer": "Integer",
              "oilanomaly": "Integer",
              "outsideTemperature": "Temperature",
              "parking_brake_status": "Integer",
              "speed": "Integer",
              "timestamp": "Text",
              "tirepressure": "Integer",
              "transmission_gear_position": "Text",
              "vin": "Text",
              "windshield_wiper_status": "Integer"
            }
          }
        }
      },
      "Type": "Bus",
      "VIN": "Y3J9PV9TN36A4DUB9",
      "Borough": "Manhattan"
    ```

    ![In the Device Twin blade, set desired properties and save.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image214.png 'Device Twin Blade')

### Task 2: Provision new Linux virtual machine to run as the IoT Edge device

In this task, you will provision a new Linux virtual machine that will be used to run the IoT Edge device, using an Azure IoT Edge on Ubuntu virtual machine available from the Azure Marketplace.

1.  Open the following URL in a new browser window: <https://azuremarketplace.microsoft.com/en-us/marketplace/apps/microsoft_iot_edge.iot_edge_vm_ubuntu?tab=overview>.

2.  Log in with the same Azure account you are currently using.

3.  Press the **GET IT NOW** button, then **Continue** to open the deployment template in the Azure Portal.

    ![In the Marketplace web page for Azure IoT Edge on Ubuntu, press the GET IT NOW button](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image200.png 'Azure Marketplace')

4.  In the Azure portal press the **Create** button to initiate the provisioning.

5.  Complete the quickstart template form with the following parameters:

    a. **Subscription**: Select the same subscription you've been using for the lab.

    b. **Resource group**: Select the same resource group you've been using.

    c. **Region**: Should be the same as the location of your resource group and other services.

    d. **Image**: Select **Ubuntu Server 16.04 LTS + Azure IoT Edge runtime**

    e. **Size**: **Standard B1ms** is sufficient for this exercise.

    ![Ubuntu Virtual Machine Settings](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image201.png 'Create a Virtual Machine Blade')

    f. **Authentication**: Select **Password**.

    g. **Admin Username**: **Make note of the username you enter** so you can use it later.

    h. **Admin Password**: **Make note of the password you enter** so you can use it later.

    i. **Public inbound ports**: Select **Allow selected ports**.

    j. **Select inbound ports**: Select **SSH (22)**.

    ![Ubuntu Virtual Machine Settings](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image202.png 'Create a Virtual Machine Blade')

6.  Then select **Review + create**, then after validation passes, press the **Create** button to deploy the Virtual Machine.

7.  Once created, access the VM's overview blade, select **Connect**. Copy the SSH command.

    ![The ssh command is highlighted, and the Connect button is selected in the Virtual machine blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image82.png 'Virtual machine blade')

8.  Open your Bash client and paste the SSH command, then press **Enter**.

9.  When asked whether you want to continue connecting, enter **yes**.

10. Enter the password you provided when provisioned the IoT Remote Monitoring solution.
    ![In the Bash window, the SSH command and the Yes response are both called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image83.png 'Bash window')

11. Enter the following command to update the container device connection string (replace value with the **IoT Hub connection string** you copied in Task 1 above):

    ```
    sudo /etc/iotedge/configedge.sh "{IoT Hub -> IoT Edge device connection string}"
    ```

12. Execute the following Docker command to see that the IoT Edge agent is running as a module:

    ```
    sudo iotedge list
    ```

    ![The Bash window displays with the previous docker command.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image85.png 'Bash window')

    > If you do not see your device right away, re-run the `sudo iotedge list` command after a few seconds.

### Task 3: Create and deploy the custom C\# IoT Edge module for vehicle telemetry

In this task, you will use Visual Studio Code to complete the custom C\# IoT Edge module that simulates vehicle telemetry representing bus sensor data. Then you will create the Docker container, and register it in your Container Registry instance so it can be deployed to the IoT Edge device.

1.  Open Visual Studio Code.

2.  Select **File Open Folder**...

    ![File/Open Folder is selected in the Visual Studio Code window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image86.png 'Visual Studio Code window')

3.  Browse to the lab-files in the Hands-on lab folder. Select the **VehicleTelemetrySimulator**.

4.  You may see one or more errors about unresolved dependencies or needing to add build and debug assets. Dismiss these messages, as they are not pertinent to the IoT Edge module project.

    ![In the Visual Studio Code window, the Don't ask again and Close buttons are called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image87.png 'Visual Studio Code window')

5.  Open **Program.cs** under the **modules** folder.

![In the Explorer window, the modules folder is open and Program.cs is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/imageModuleProgramcs.png 'Explorer window')

7.  Complete the code for TODO items 1-7.

    a. Within the **UpdateReportedPropertiesFromDesired** method:

    - Set the local and reported vin value to the VIN specified in the device twin.

    ```
    if (desired["VIN"] != null)
    {
        // TODO: 1 - Set the vin to the value in the device twin
        vin = desired["VIN"];
        reportedProperties["VIN"] = vin;
    }
    ```

    - Set the local and reported borough value to the Borough specified in the device twin.

    ```
    if (desired["Borough"] != null)
    {
        // TODO: 2 - Set the borough to the value in the device twin
        borough = desired["Borough"];
        reportedProperties["Borough"] = borough;
    }
    ```

    - Set the local and reported telemetry value to the Telemetry specified in the device twin

    ```
    if (desired["Telemetry"] != null)
    {
        // TODO: 3 - Set telemetry to the value in the device twin
        telemetry = desired["Telemetry"];
        reportedProperties["Telemetry"] = telemetry;
    }
    ```

    - Set the local and reported type value to the Type specified in the device twin

    ```
    if (desired["Type"] != null)
    {
       // TODO: 4 - Set telemetry to the value in the device twin
       type = desired["Type"];
       reportedProperties["Type"] = type;
    }
    ```

    - Update reported properties with the IoT Hub

    ```
    // TODO: 5 - update reported properties with the IoT Hub
    await ioTHubDeviceClient.UpdateReportedPropertiesAsync(reportedProperties);
    ```

    b. Within the **GenerateMessage** method:

    - Use the Module Client instance (IoTHubModuleClient) to asynchronously send the event message, using the specified output name (outputName).

    ```
    // TODO: 6 - Have the Module Client send the event message asynchronously, using the specified output name
    await ioTHubModuleClient.SendEventAsync(outputName, message);
    ```

    c. Within the **Init** method:

    - Add the **device connection string** (replace `<connectionstring>`) to the ioTHubDevice client initialization code

    ```
    //TODO: 7 - set device connection string for the device client
    ioTHubDeviceClient = DeviceClient.CreateFromConnectionString("<connectionstring>");
    ```

8.  Save your changes.

9.  In VS Code, open **module.json**, in the repository property, change the URI to **LOGIN SERVER/vehicletelemetrysimulator**, replacing the login server value with your container registry login server value.

    ![Image Repository](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image199.png 'Image Repository')

10) Sign in to Docker by entering the following command in the VS Code integrated terminal, using the Container Registry credentials and server information:

    ```
    docker login -u <username>    -p <password>    <Login server>
    ```

11) To build the project and Push it to the IoT Edge Module Image, right-click the **module.json** file in the Explorer and select **Build and Push IoT edge Module Image**.

    ![Right-click the VehicleTelemetrySimulator.csproj file, then select Convert to IoT Edge Module.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image89.png 'Convert to IoT Edge module')

12) select **amd64** as the platform of choice. This will create a Linux-based Docker image.

    ![Select amd64 as the platform choice.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image91.png 'Select Platform')

13) Watch the VS Code terminal window. You should see a success status when the build is complete. **Take note of the tag applied to your vehicle-telemetry-simulator image**. You will need to use this tag when you add the module to your IoT Edge device via the portal later on.

    ![Next to "Successfully tagged," the tag is called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image92.png 'VS Code terminal window')

### Task 4: Create the Azure Stream Analytics IoT Edge module

In this task, you will create a Stream Analytics job that filters vehicle telemetry data generated by the custom C\# module, and outputs only the most important data to potentially two different outputs in IoT Hub.

1.  Navigate to the Azure Portal, <http://portal.azure.com>.

2.  Browse to your solution's resource group and locate the provisioned Azure Storage account whose name begins with "storage".

    ![In the Azure Portal, under Name, the storageh57yy storage account is selected.](media/resource-group-storage-account.png 'Azure Portal')

3.  Make a note of the name, as it will be used to store Azure Stream Analytics data.

4.  Open the storage account and select **Blobs** from the menu to the left.

5.  Select **+ Container** at the top of the Containers blade, then provide the following:

    a. **Name**: asa-container

    b. **Public access level**: Container

    ![Fields in the Storage account blade are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image95.png 'Storage account blade')

6.  Select **+ Create a resource**, then type **stream analytics** into the search box on top. Select **Stream Analytics job** from the results.

    ![The search field in the Azure Portal is set to stream analytics.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image96.png 'Azure Portal')

7.  Select the **Create** button on the Stream Analytics job overview blade.

8.  On the Create namespace blade, specify the following configuration options:

    a. **Name**: Unique value for the Job name (ensure the green check mark appears).

    b. Specify your **Resource Group**, ensuring it's the same one in which your new components have been created.

    c. Select the same **location** as your Resource Group and other services. Please note: Currently, Azure Stream Analytics jobs on IoT Edge aren't supported in the West US 2 region.

    d. Select the **Edge** hosting environment.

    ![In the New Stream Analytics job blade, fields are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image97.png 'New Stream Analytics job blade')

9.  Select **Create**.

10. In the created job, under **Job Topology**, select **Inputs**, and then select **+ Add stream input**, then select **Edge Hub**.

    ![Select Add stream input, then Edge Hub.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image98.png 'Inputs blade')

11. Provide the following configuration in the New input blade:

    a. **Input alias**: VehicleTelemetry

    b. **Event-serialization format**: JSON

    c. **Encoding**: UTF-8

    d. **Compression**: None

    ![Enter VehicleTelemetry for the input aliase, then save.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image99.png 'Edge Hub new input')

12. Select **Save**.

13. Under **Job Topology**, select **Outputs**, and then select **+ Add**, then select **Edge Hub**.

14. Provide the following configuration in the New output blade:

    a. **Input alias**: Alert

    b. **Event-serialization format**: JSON

    c. **Encoding**: UTF-8

    ![Set the Output alias to Alert.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image100.png 'Edge Hub new output')

15. Select **Save**.

16. Select **+ Add** under **Outputs** to create a new output that will trigger the route you created in IoT Hub earlier, that sends events filtered on the EngineAlert output, to the custom endpoint and on to the Service Bus Queue.

17. Provide the following configuration in the New output blade:

    a. **Input alias**: EngineAlert

    b. **Event-serialization format**: JSON

    c. **Encoding**: UTF-8

    ![Enter EngineAlert for the Output alias.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image101.png 'Edge Hub new output')

18. Select **Save**.

19. Go back to the Stream Analytics job overview pane. You will see the input and two outputs you created. Select **Edit query** to the right of the displayed Query container.

    ![In the Stream Analytics overview blade, Edit query is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image102.png 'Stream Analytics overview blade')

20. Create a step that averages the engine temperature and speed over a two second duration. Create another step that selects all telemetry data, including the average values from the previous step, and specifies the following anomalies as new fields:

    a. **enginetempanomaly**: When the average engine temperature is \>= 405 or \<= 15.

    b. **oilanomaly**: When the engine oil \<= 1.

    c. **aggressivedriving**: When the transmission gear position is in first, second, or third, and the brake pedal status is 1, the accelerator pedal position \>= 90, and the average speed is \>= 55.

21. Have the query output all fields from the anomalies step into the Alert output where aggressivedriving = 1 or enginetempanomaly = 1.

22. Have the query output all fields from the anomalies step where the enginetempanomaly = 1 and oilanomaly = 1.

23. Here is the completed query:

    ```sql
    WITH
    Averages AS (
    select
        AVG(engineTemperature) averageEngineTemperature,
        AVG(speed) averageSpeed
    FROM
        VehicleTelemetry TIMESTAMP BY [timestamp]
    GROUP BY
        TumblingWindow(Duration(second, 2))
    ),
    Anomalies AS (
    select
        t.vin,
        t.[timestamp],
        t.outsideTemperature,
        t.engineTemperature,
        a.averageEngineTemperature,
        t.speed,
        a.averageSpeed,
        t.fuel,
        t.engineoil,
        t.tirepressure,
        t.odometer,
        t.accelerator_pedal_position,
        t.parking_brake_status,
        t.headlamp_status,
        t.brake_pedal_status,
        t.transmission_gear_position,
        t.ignition_status,
        t.windshield_wiper_status,
        t.abs,
        (case when a.averageEngineTemperature >= 405 OR a.averageEngineTemperature <= 15 then 1 else 0 end) as enginetempanomaly,
        (case when t.engineoil <= 1 then 1 else 0 end) as oilanomaly,
        (case when (t.transmission_gear_position = 'first' OR
            t.transmission_gear_position = 'second' OR
            t.transmission_gear_position = 'third') AND
            t.brake_pedal_status = 1 AND
            t.accelerator_pedal_position >= 90 AND
            a.averageSpeed >= 55 then 1 else 0 end) as aggressivedriving
    from VehicleTelemetry t TIMESTAMP BY [timestamp]
    INNER JOIN Averages a ON DATEDIFF(second, t, a) BETWEEN 0 And 2
    )
    SELECT
        *
    INTO
        Alert
    FROM
        Anomalies
    where aggressivedriving = 1 OR enginetempanomaly = 1
    SELECT
        *
    INTO
        EngineAlert
    FROM
        Anomalies
    where enginetempanomaly = 1 AND oilanomaly = 1
    ```

24. Test the query with sample data. Right-click the **VehicleTelemetry** input and select **Upload sample data from file**.

    ![Under Inputs, Vehicle Telemetry is selected, and from its right-click menu, Upload sample data from file is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image103.png 'Inputs section')

25. Use the browse button to select the **sample-vehicle-telemetry.json** file extracted to the Lab-files folder from the starter solution zip file you downloaded. This file contains \~5000 JSON records of simulated vehicle telemetry.

    ![In the Upload test data blade, the browse field is set to the previously defined file.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image104.png 'Upload test data blade')

26. Select **OK**.

27. Select **Test** in the toolbar above the query.

    ![In the Query blade, the Test button (gear icon) is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image105.png 'Query blade')

28. Explore the results. The Alert output should have around 2,231 rows, and the EngineAlert output 48.

    ![In the Results section, enginealert and 48 rows are both selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image106.png 'Results section')

29. **Save** the query.

### Task 5: Deploy the custom modules to IoT Edge device

In this task, you will deploy the vehicle telemetry module and Stream Analytics module to the IoT Edge device. Both will be deployed simultaneously so you can register the module routes to send vehicle telemetry data to the Stream Analytics module, then send the filtered data upstream to IoT Hub as needed.

1.  Open your **IoT Hub**.

2.  Select **IoT Edge** from the left-hand menu, then select your IoT Edge device to open the details page.

    ![In the IoT Hub, under Explorers, IoT Edge (preview) is selected. Under IoT Edge Devices, bus1 is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image107.png 'IoT Hub')

3.  Select **Set Modules**.

    ![Set Modules is selected in the Device Details blade top menu.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image108.png 'Device Details blade')

4.  In the **Container Registry Settings** add an entry with your container registry name, username and password.
    ![Add IoT Edge Container Registry connection information.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image204.png 'Container Registry connection information')

5.  From the **Deployment Modules** section Select **Add IoT Edge Module**.

    ![Add IoT Edge Module is selected in the Device Details blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image109.png 'Device Details blade')

6.  Enter the following configuration values in the IoT Edge Module form:

    a. **Name**: VehicleTelemetry

    b. **Image URI**: The image URI path you specified when you created the Docker image and registered it in Azure Container Registry. Should be in the form of **\<your container registry address\>/vehicle-telemetry-simulator:0.0.1-amd64** (the tag should be the same as defined when your docker image was created in VS Code).

    c. **Restart Policy**: always

    d. **Desired Status**: running

    ![Specify the name, image URI, and module twin's desired properties.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image110.png 'IoT Edge Module blade')

7.  Select **Save**.

8.  Select **Select Azure Stream Analytics Module**.

    ![Import Azure Stream Analytics to IoT Edge Module is selected in the Device Details blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image111.png 'Device Details blade')

9.  Select your Azure subscription, then the Stream Analytics job you created in the previous task.

10. if you are missing a storage account setting, click on the link to set it up.


    ![Missing Storage Account.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image205.png "Missing Storage Account")

11. Once the Stream Analytics Job Storage Account Settings blade is opened, press the **Add storage account** button.

    a. **Storage Account Settings**: select **Select storage account from your subscriptions**.

    b. **Subscription**: select your desired subscription.

    c. **Storage account**: select the storage account in which you created the **asa-container** blob earlier.

    d. **Container**: select **Use existing**, then select **asa-container**

    ![In the Edge deployment blade, fields are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image112.png 'Edge deployment blade')

12. Select **Save**.

13. Return to the Stream Analytics - Edge job blade, and press **Save**, this will publish the module.

14. Once published, copy the name of your Stream Analytics module.

    ![iot-lab-edge is selected on the Set Modules page on the Set Modules blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image113.png 'Set Modules blade, Set Modules page')

15. Select **Next**.

16. Copy the following code to Routes. Replace _{moduleName}_ with the Stream Analytics module name that you copied:

    ```javascript
    {
        "routes": {
            "alertsToCloud": "FROM /messages/modules/{moduleName}/outputs/* INTO $upstream",
            "telemetryToAsa": "FROM /messages/modules/VehicleTelemetry/outputs/* INTO BrokeredEndpoint(\"/modules/{moduleName}/inputs/VehicleTelemetry\")"
        }
    }
    ```

    ![The previously designated code displays in the code window on the Specify Routes page.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image114.png 'Set Modules blade, Specify Routes page')

17. Select **Next**.

18. In the Review Template step, select **Submit**.

19. After approximately 4 minutes, return to the device details page. You should see the two new modules running, along with the IoT Edge agent module and the IoT Edge hub.

    ![On the Deployed Modules tab, under Name, iot-lab-edge and VehicleTelemetry are called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image115.png 'Device Details page Deployed Modules tab')

20. Go back to your Bash shell that is connected to the Linux VM containing your IoT Edge device.

21. Execute the following to make sure all the modules are running in Docker:

    ```
    sudo iotedge list
    ```

    ![Displays the list of docker images running in the IoT Edge simulator VM.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image116.png 'Bash shell')

22. You should have four containers running at this point.

23. View the Stream Analytics module logs to see the telemetry it is reading, as well as any outputs it generates based on anomalies. You should see a large degree more vehicle telemetry feeding into the Stream Analytics module than what it sends out. This, of course, is by design. Replace {moduleName} with the Stream Analytics module name. Press <kbd>Ctrl/Cmd</kbd>+<kbd>c</kbd> to return to the command line.

    ```
    sudo iotedge logs -f {moduleName}
    ```

    ![In the Output window, results from the Stream Analytics module logs display.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image206.png 'Output window')

24. View the generated data by viewing the log for the VehicleTelemetry module as follows. Press <kbd>Ctrl/Cmd</kbd>+<kbd>c</kbd> to return to the command line.

    ```
    sudo iotedge logs -f VehicleTelemetry
    ```

25. Notice the log output as shown below. There are many "Received message Name: \[VehicleTelemetry\]" events, and one output generated (highlighted). The output name is **alert**, matching one of the two outputs we created in the Stream Analytics module. The message content is sent to IoT Hub, including the additional fields added by the Stream Analytics query. In this case, the telemetry data is flagged as aggressive driving (aggressivedriving: 1).

![In the Output window, results from the Vehicle Telemetry module logs display.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image207.png 'Output window')

25. Leave the IoT Edge device running for the remainder of the lab.

## Exercise 5: Create an Azure Function to add critical engine alerts to the Service Bus Queue

As you remember, you created an Azure Service Bus Queue to hold messages flagged as critical engine alerts. This queue is to be fed messages from the IoT Hub that match a certain criteria. In this exercise, you will create the Azure Function that reads messages from the IoT Hub, identifies messages fitting the criteria and moves this information to the alert-q created earlier in this lab.

### Task 1: Create a new Function App

A Function app is a logical collection of functions on the Azure platform. Each Function app may have multiple functions contained within. Create a new Function App

1.  Using a new tab or instance of your browser navigate to the Azure Management portal, <http://portal.azure.com>.

2.  Select **+ New**, then type **function app** into the search box on top. Select **Function App** from the results.

    ![The Search field in the New blade is set to Function Ap.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image127.png 'Azure Portal New blade')

3.  Select the **Create** button on the Function App overview blade.

4.  On the Create Function App blade, specify the following configuration options:

    a. **Name**: Unique value for the app name (ensure the green check mark appears).

    b. **Subscription**: select a valid subscription.

    c. Specify your **Resource Group**, ensuring it's the same one in which your new components have been created.

    d. **OS**: Windows

    e. **Hosting Plan**: Consumption Plan

    f. Select the same **location** as your Resource Group and other services.

    g. **Runtime Stack**: select **JavaScript**

    h. Select **Create new** under storage.

    ![In the Function App blade, fields display with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image128.png 'Function App blade')

5.  Select **Create**.

### Task 2: Add new Function to process messages received by the IoT Hub

1. Access the Function App provisioned in the Azure Portal, by selecting **Function Apps** in the left-hand menu, then select the Function App that you created in the last task.

   ![Accessing the provisioned Function App.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image215.png 'Accessing the provisioned Function App.')

2. Underneath the Function App, select the **Functions** item, and press the **New function** button.

   ![Create new Function](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image216.png 'Create new Function')

3. In the template search box, type IoT Hub, then select **IoT Hub (Event Hub)**.

   ![IoT Hub Template](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image217.png 'IoT Hub Template')

4. You may be prompted to install an extension, press the **Install** button if prompted.

   ![Install Extension](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image218.png 'Install Extension')

5. Name the function, and for the event hub trigger, press **new** and select the built-in event endpoint. For the Event Hub Consumer group, enter the **queuefuncconsumergroup** that you created on the IoT Hub earlier.

   ![Create IoT Hub Function Blade](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image219.png 'Create IoT Hub Function Blade')

   ![Select IoT Hub Events endpoint](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image220.png 'Select IoT Hub Events Endpoint')

6. Press the **Create** button.

7. This function will be responsible for analyzing instant measurements of engine oil and engine temperature. The threshold for engine oil is to flag any values less than 20, and any engine temperatures greater than 400. Readings that are flagged are to be put into the Service bus **alert-q** that we created earlier in this lab.

8. In order to moved flagged messages to the queue, we must declare a Service Bus output for our function. Beneath our function, press the **Integrate** button.

   ![Azure Function Integrate](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image223.png 'Azure Function Integrate')

9. Next, select **New Output** from beneath the **Outputs** header, and select the **Azure Service Bus** item and press the **Select** button.

   ![Define function output](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image224.png 'Define function output')

10. You may be prompted to install further extensions, please do so by clicking the install link.

    ![Install extensions](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image225.png 'Install Extensions')

11. Define the output as the following:

    a. **Message Type**: Service Bus Queue

    b. **Service Bus connection**: press **new** then select the service bus that you created early on in this lab.

    ![Select the Service Bus](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image226.png 'Select the Service Bus')

    c. **Message Parameter Name**: engineAlertOutput

    d. **Queue name**: alert-q

    ![Service Bus Queue Output Settings](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image227.png 'Service Bus Queue Output Settings')

12. Press **Save** to create the Output.

13. Select the function in the left hand menu, and in the **index.js** file, replace the listing with the following code:

    ```
    module.exports = function (context, IoTHubMessages) {
        var engineAlerts = [];
        IoTHubMessages.forEach(message => {

            if((message.engineoil && message.engineoil<20) || (message.enginetemperature && message.enginetemperature>400)){
                context.log("Engine Oil: "+ message.engineoil +" - Engine Temperature: "+ message.enginetemperature);
                engineAlerts.push(JSON.stringify(message));
            }
        });
        context.log("ENGINE ALERTS COUNT: "+ engineAlerts.length);
        if(engineAlerts.length > 0) {
            context.bindings.engineAlertOutput = engineAlerts;
        }

        context.done();
    };
    ```

14. Save the code, and watch the console logs for output.

    ![Function Console Output](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image228.png 'Function Console Output')

15. After you've seen one or more engine alerts recorded in the console output, verify the Service Bus queue has messages. Access the queue in the Azure portal, by selecting **All Resources**, and choosing the **Service Bus** item, then selecting **Queues** and **alert-q**.

    ![Access the Service Bus Queue](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image229.png 'Access the Service Bus Queue')

16. You should see one or more messages ready for processing on the queue.

![Queue Details](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image230.png 'Queue Details')

## Exercise 6: Run a console app to view critical engine alerts from the Service Bus Queue

As you remember, you created an Azure Service Bus Queue to ingest messages flagged as critical engine alerts. This queue is to be fed messages from the IoT Hub that match a certain criteria. In this exercise, you will create the Azure that reads the Service Bus queue one-at-a-time so you can easily view the contents of the alerts.

**Duration:** 10 minutes

### Help references

|                                                               |                                                                                                                                             |
| ------------------------------------------------------------- | :-----------------------------------------------------------------------------------------------------------------------------------------: |
| **Description**                                               |                                                                  **Links**                                                                  |
| Use the Service Bus .NET SDK to receive messages from a queue | <https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues#4-receive-messages-from-the-queue> |

### Task 1: Retrieve the Service Bus Queue Connection string

1.  Once again, open your **Service Bus** instance in the Azure Portal.

2.  Select **Shared access policies** from the left-hand menu.

3.  Select the **RootManageSharedAccessKey** policy, then copy the **Primary Connection String** and save it for the next task.

    ![In the Service Bus blade, under Settings, Shared access policies is selected. Under Policy, RootManageSharedAccessKey is selected. The copy button is selected for the Primary Connection String.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image120.png 'Service Bus blade')

### Task 2: Configure and execute the ReadEngineAlerts solution in Visual Studio 2017

1.  Browse to the Lab-files folder containing the extracted solution files for the lab.

2.  Open **ReadEngineAlerts\\ReadEngineAlerts.sln**.

3.  Open **Program.cs** from the Solution Explorer.

4.  Locate the **connectionString** variable and replace {YOUR-CONNECTION-STRING} with the Service Bus connection string that you copied in the previous task.

    ![In Solution Explorer, Program.cs is selected, and the connectionString variable is circled.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image121.png 'Solution Explorer')

5.  Right-click the **ReadEngineAlerts** project in Solution Explorer, then select **Start new instance** in the **Debug** submenu.

    ![In Solution Explorer, ReadEngineAlerts is selected, and from its right-click menu, Debug and Start new instance are selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image122.png 'Solution Explorer')

6.  You should start to see critical alerts flowing in to the console window.

    ![Critical alerts display with varying colors in the Console window.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image123.png 'Console window')

7.  Notice that all values have a 1 in both the enginetempanomaly and oilanomaly properties. This is due to the filter you defined within the Stream Analytics IoT Edge module.

8.  You may close the console when you are finished reviewing the data.

## Exercise 7: Create an Azure Function to ingest critical engine alerts and store them in Cosmos DB

**Duration:** 45 minutes

The console app is a fast and effortless way to view the critical engine alerts flowing through the Service Bus Queue, but it isn't very practical for establishing any business or processing workflow. Azure Functions makes it easy to ingest messages from service Bus, because it provides a Service Bus trigger that executes the function and passes the message object as soon as it is added to the queue. The automated scalability of Azure Functions means that it will add more resources as needed to keep up with demand during peak loads, then scales the resources back down during quieter periods. Azure Functions also provides a Cosmos DB output that makes it very simple to write data to Cosmos DB, which is another massively scalable service. Since other data is already being stored in Cosmos DB, it is a natural choice for these alerts.

### Help references

|                                                |                                                                                         |
| ---------------------------------------------- | :-------------------------------------------------------------------------------------: |
| **Description**                                |                                        **Links**                                        |
| Azure Service Bus bindings for Azure Functions | <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-service-bus> |
| Azure Cosmos DB bindings for Azure Functions   |  <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-cosmosdb>   |

### Task 1: Create a new Function

1.  Open the Azure Function App resource that we created earlier.

2.  Select **Functions** on the left-hand menu, then select **+ New function**.

    ![New function and Functions are both selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image129.png 'New function')

3.  Type **service bus** in the search box to filter the template list.

4.  Select the **Azure Service Bus Queue trigger** template.

    ![On the Choose a template page, Service bus is typed in the search field.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image130.png 'Choose a template page')

5.  You may be prompted to install an extension, press **Install** if you see this message.

    ![Install extensions if prompted](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image208.png 'Install Extension')

6.  In the form that follows, provide the following configuration values:

    a. **Name**: BusEngineAlert

    b. **Service Bus connection**: Select **new**, then find and select your Service Bus in the dialog box.

    c. **Queue name**: alert-q

    ![The Connection window displays](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image131.png 'Connection window')

    ![In the Service Bus Queue trigger New Function form, fields are set to the previously defined settings](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image132.png 'New function form')

6)  Select **Create**.

### Task 2: Add an Azure Cosmos DB output to the critical-alerts collection

1.  Expand the new **BusEngineAlert** function and select **Integrate**.

    ![Uder Functions, BusEngineAlert is expanded, and Integrate is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image133.png 'Functions section')

2.  Select **+ New Output** under **Outputs**.

3.  Select **Azure Cosmos DB** from the list.

4.  Select **Select**.

    ![Under Outputs, New Output is selected, and below, the Azure Cosmos DB tile is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image134.png 'Integrate section')

5.  Provide the following values for the Azure Cosmos DB output:

    a. **Document parameter name**: criticalAlertDocument

    b. **Database name**: pcs-iothub-stream

    c. **Collection Name**: critical-alerts

    d. **Azure Cosmos DB account connection**: Select the same connection you created for the other output.

    ![Fields under Azure Cosmos DB output are set to the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image137.png 'Azure Cosmos DB output ')

6.  Select **Save**.

### Task 3: Modify the function code

1.  Select the new **BusEngineAlert** function to view the code editor.

    ![Under Functions, BusEngineAlert is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image138.png 'Functions section')

2.  The function code is responsible for storing Engine Alert data in Cosmos DB partitioned by the unique VIN value for the device. Earlier, we have already declared the **critical-alerts** collection in Cosmos DB partitioned by the VIN, so all we need to do now is to read the information from the queue and move the data over.

3.  The **complete code** is as follows:

    ```
    module.exports = function (context, alert) {
            var criticalAlertContent = JSON.stringify(alert);
            // Save the alarm to Cosmos DB
            context.bindings.criticalAlertDocument = criticalAlertContent;
        }
        context.done();
    };
    ```

    ![The index.js window displays.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image139.png 'index.js window')

4.  **Save** your changes.

5.  Select **Run** to view the output logs of the function. You should see successful function completed events.

    ![Output logs display, with two success messages highlighted.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image140.png 'Output logs')

### Task 4: View data stored by the function in Azure Cosmos DB

Apply a query filter on the messages collection to view the critical engine alert messages. These messages are stored for downstream systems that are out of the scope of the lab.

1.  Navigate back to your Azure Cosmos DB account. Select **Data Explorer** from the left-hand menu.

    ![Data Explorer is selected in the Azure Cosmos DB account blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image211.png 'Azure Cosmos DB account blade')

2.  Right-click on the **critical-alerts** collection under pcs-iothub-stream, then select **New SQL Query**.

    ![Under Collections, pcs-iothub-stream is expanded, and messages is selected. From its right-click menu, New SQL Query is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image141.png 'Collections section')

3.  Enter the following query, then select **Execute Query** to view the results:

    ```
    SELECT * FROM c
    ```

    ![On the Query 1 tab, the Results 1 - 87 message is called out, and results display below.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image142.png 'Query 1 tab')

4.  Expand the **critical-alerts** collection and select **Documents**. Choose one of the documents to view. You will see the full message data for the critical alert.

    ![Under Collections, ics-iothub-stream is expanded, Critical-alerts is expanded, and Documents is selected. On the Documents tab, a document id is selected, and the message data for the critical alert displays.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image143.png 'Collections section')

## Exercise 8: View critical engine alerts in the IoT Remote Monitoring web interface

We also have the ability to identify critical engine alerts by defining rules in the IoT Remote Monitoring web interface.

### Task 1: View the bus data coming from IoT Edge

Navigate back to the monitoring web app. If you don't remember the path or have closed the previous browser session, the naming convention is \[your solution name\].azurewebsites.net. You may need to refresh the browser window if it has been running for some time and is unresponsive.

1. From the device groups drop down at the top of the dashboard, select **Buses**

2. You should see additional telemetry options above the graph at the bottom of the page, indicating availability of data from the new fields that are part of the critical engine alerts. Select **enginetemperature**.

   ![The Monitoring Web App dashboard displays a Telemetry graph of averageenginetemperature [1] for bus1.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image144.png 'Monitoring Web App dashboard')

### Task 2: Define new alert rules for buses

1. Define a new rule for Buses by selecting **Rules** in the left-hand menu, then press the **New rule** button (ensure **Buses** are still the selected device group).

   ![Add a new Buses Rule](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image231.png 'Add new Rule')

2. Define the rule as follows, then press **Apply** to add the rule to the IoT Hub Stream Analytics:

   a. **Rule Name**: Engine Temperature

   b. **Description**: Alert when an Engine Temperature is above threshold

   c. **Device Group**: Select **Buses**.

   d. **Calculation**: Select **Instant**.

   e. Condition 1 **Field**: Select **engineTemperature**.

   f. **Operator**: Select **> Greater than**.

   g. **Value**: 400

   h. **Severity level**: Select **Critical**.

   ![Add a new Buses Rule](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image232.png 'Add new Rule')

   ![Add a new Buses Rule](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image233.png 'Add new Rule')

3. Define a second rule for Buses by adding another rule for the Engine Oil alerts, press **New Rule** and create the rule as follows, then press **Apply**:

   a. **Rule Name**: Engine Oil

   b. **Description**: Alert when an Engine Oil drops below threshold

   c. **Device Group**: Select **Buses**.

   d. **Calculation**: Select **Instant**.

   e. Condition 1 **Field**: Welect **engineoil**.

   f. **Operator**: Select **< Less than**.

   g. **Value**: 20

   h. **Severity level**: Select **Critical**.

   ![Bus Rules](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image234.png 'Bus Rules')

4. Give it some time, and watch the dashboard for new critical warnings based on the rules that were just created.

   ![Dashboard with Bus Alerts](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image234.png 'Dashboard with Bus Alerts')

## Exercise 9: Add a tag to IoT Edge Device Twin

In this exercise, you will create the following tag that will be saved to the device twin: Name: isEdgeDevice, Value: Y. You will then use this tag as the basis for a new device filter in the web UI for displaying Edge devices.

### Task 1: Create the tag update job

1.  Select **Device Explorer** from the left-hand menu.

2.  You will see your IoT Edge device, Bus1, listed with a value of No for Simulated. Check the box next to the IoT Edge device, then select **Jobs** from the top menu.

    ![In the list of devices, Bus1 is selected, and Simulated is set to No.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image146.png 'Devices list')

3.  In the Jobs panel, select **Tag**. Enter the following configuration for the new tag:

    a. **Job Name**: edgetag

    b. Select **+ Add** tag, then enter the following values:

    - **Name**: IsEdgeDevice
    - **Value**: Y

    ![Fields in the Tag section are set to the previously mentioned settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image147.png 'Tag section')

4.  Select **Apply**.

### Task 2: Verify tag update in the device twin

1.  Navigate to your IoT Hub instance in the portal.

2.  Go to **IoT Edge**, then select your IoT Edge Device from the list.

3.  In the device details blade, select **Device Twin** from the top.

    ![In the Device Details blade, the Device Twin button is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image149.png 'Device Details blade')

4.  You should see the new tag in the device twin. If not, try selecting the refresh button.

    ![In the Device Twin blade, the new tag is called out. ](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image150.png 'Device Twin blade')

### Task 3: Create new IoT Edge device group

1. Switch back over to the monitoring site, then select **Manage Device Groups** on top of the page, as done earlier in the lab.

2. Select **+ Create new device group**.

3. Provide the following configuration for the new filter:

   a. **Name**: Edge Devices

   b. **Field**: tags.IsEdgeDevice

   c. **Operato**r: = Equals

   d. **Value**: Y

   e. **Type**: Text

   ![Fields in the Create filter section are set to the previous values.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image151.png 'Create filter section')

4. Select **Save**.

5. Select your new filter as the device group for the dashboard.

6. Notice that only one device is reported and displayed.

   ![The Monitoring Web App dashboard displays information for only one Edge Device.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image152.png 'Monitoring Web App dashboard')

## Exercise 10: View all data in Azure Time Series Insights

**Duration:** 15 minutes

Now that the critical engine alert data is being recorded, we can view this data in Time Series Insights as well.

### Help references

|                                     |                                                                                             |
| ----------------------------------- | :-----------------------------------------------------------------------------------------: |
| **Description**                     |                                          **Links**                                          |
| What is Azure Time Series Insights? | <https://docs.microsoft.com/en-us/azure/time-series-insights/time-series-insights-overview> |
| Azure Time Series Insights explorer | <https://docs.microsoft.com/en-us/azure/time-series-insights/time-series-insights-explorer> |

### Task 1: Add your account as a Contributor to the Data Access Policies

Before you can access the Time Series Insights environment and make changes, you need to make sure your account is added as a Contributor to the Data Access Policies. This is where you add additional users who can access this data. You should have already been added as a Contributor by utilizing the IoT Remote Monitoring Accelerator. If this is not the case, please follow the following steps.

1.  Open your Azure Time Series Insights instance in the portal.

2.  Select **Data Access Policies** from the left-hand menu.

3.  If your account is not listed as a contributor, select **+ Add** from the Data Access Policies blade.

    ![The Add button is selected in the Data Access Policies blade.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image153.png 'Data Access Policies blade')

4.  Select your user account by using the search field, then select both the **Reader** and **Contributor** roles for your user account.

    ![In the Select Role blade, the check boxes for Reader and Contributor are selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image154.png 'Select Role blade')

5.  Select **Ok** twice to go back to the Data Access Policies blade. You should now see your account listed with the Reader and Contributor roles.

### Task 2: Go to the Time Series Insights environment and use the data explorer

1.  Select **Overview** from the left-hand menu, then select **Go to Environment**.

    ![In the Data Access Policies blade, the Go to Environment button is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image155.png 'Data Access Policies blade')

2.  The Time Series Insights data explorer will open in a new tab. By default, a chart displaying a count of all events is displayed. Notice how there is a timeline directly underneath the chart, and a more macro-level timeline below that, showing a span of several hours.

    ![A chart displays for 1 series of 1 total in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image156.png 'Time Series Insights Data Explorer')

3.  Use the **Terms Editor Panel** located on the left-hand side of the screen to query your environment. Select **Add**.

    ![Add is selected in the Terms Editor Panel.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image157.png 'Terms Editor Panel')

4.  The Measure drop down shows all numeric columns (Doubles), and the Split By drop down shows categorical columns (Strings). To compare voltages for the traffic lights, select **voltage** under Measure, then **serial_number** under Split By.

    ![The Measure and Split by fields are called out.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image158.png 'Measure and Split by fields')

5.  You will now see the two traffic lights listed by serial number, on the same chart as the total event count. You can hover over a serial number to the left of the chart to highlight its place on the chart.

    ![This time, 3 series of 3 total display in chart format in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image159.png 'Time Series Insights Data Explorer')

6.  Select the **gear** within the new measure you created, then place a check in the box next to **Use Step Interpolation** and **Show Min/Max**.

    ![The Gear icon is selected and its menu displays. ](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image160.png 'Gear icon')

7.  The chart will update to reflect those changes. Notice how Show Min/Max creates a shadow behind the interpolated line to show the minimum and maximum voltage values. This is because the displayed line is the average voltage value.

    ![The described multi-dimensional chart displays in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image161.png 'Time Series Insights Data Explorer')

8.  Right-click on a line on the chart and select **Explore Events**.

    ![The right-click menu displays with Explore Events selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image162.png 'Right-click menu')

9.  You will see all the raw event data for the events displayed within the visible time range for the selected terms. You may select which columns you want to view and export the data if desired.

    ![The Events tab displays. Select all columns is selected, and raw data displays.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image163.png 'Events tab')

### Task 3: View the simulated and IoT Edge bus data side-by-side

Because all telemetry data that flows through IoT Hub is captured in Time Series Insights, it is possible to view this information in one place, creating a data context that's based on time of occurrence and any additional data points you need. In this case, we will overlay the simulated bus GPS device data from the IoT Remote Monitoring simulator, with the vehicle telemetry data generated and filtered by the bus IoT Edge device.

1.  Delete the traffic light voltage query and add a new query set in the Terms Editor Panel. Select **averageenginetemperature** as the Measure, and Split By **none**. Update the Where clause with the following: vin = \'Y3J9PV9TN36A4DUB9\'.

    ![The New Query section displays with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image164.png 'New Query section')

2.  Add a new query set. Select **speed** as the measure, and **Split By** iothub-connection-device-id. Update the Where clause with the following: vin = \'Y3J9PV9TN36A4DUB9\' AND \[iothub-connection-module-id\] = NULL.

    ![The New Query section displays with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image165.png 'New Query section')

3.  The where clause ensures that the simulated bus GPS device data matches up with the bus IoT Edge device by setting the VIN for both to the same value. Since both event sources contain a "speed" field, we want to rely on the reported speed from the GPS device, as it is updated more regularly. To do this, the where clause returns only those items whose "iothub-connection-module-id" is null. Only IoT Edge devices will contain an Id in this field.

4.  The chart shows both the average engine temperature and the reported bus speed from the GPS device stacked one on top of the other.

    ![This time, 3 series of 3 total graphs display in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image166.png 'Time Series Insights Data Explorer')

5.  To overlay the data, hide the overall event Count in the Terms Editor Panel, use step interpolation on the IoT Edge and simulated bus queries to make it easier to see the overlaid values, then deselect the stack terms option on the chart. This view may make it easier to spot correlations between different data sets, such as this one.

    ![2 series of 2 total graphs display in the Time Series Insights Data Explorer chart, and the overlay icon is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image167.png 'Time Series Insights Data Explorer')

### Task 4: Use Perspective View to create a simultaneous view of up to four unique queries

1.  Select the Perspective View icon on the upper-right corner of the chart.

    ![Screenshot of the perspective view icon.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image168.png 'Perspective view icon')

2.  Select the **Clone query** button in the empty panel to the right of the chart. This will create a new chart using the same query, making it faster to add related data.

    ![The Clone query icon is selected.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image169.png 'Clone query icon')

3.  Select the cloned chart to modify it.

    ![Two charts display (the original and the cloned) in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image170.png 'Time Series Insights Data Explorer')

4.  Remove the speed terms, then modify the IoT Edge device terms (those based on the average engine temperature) by selecting **transmission_gear_position** under Split By. This should now be the only visible term.

    ![The Edge device terms fields display with the previously defined settings.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image171.png 'Edge device terms fields')

5.  Select **Heatmap** for the chart type. It is easy to quickly spot anomalies in this view, where there are random hot and cold spots. This data is split by the transmission gear position so you can try and correlate engine temperatures with transmission gears.

    ![A heatmap displays in the Time Series Insights Data Explorer.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image172.png 'Time Series Insights Data Explorer')

6.  Go back to the Perspective View to see these two charts side-by-side.

    ![In the Time Series Insights Data Explorer Perspective view, a chart displays on the left, and a heat map displays on the right.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image173.png 'Perspective View')

7.  Select the **Save** icon to share the Perspective, give it a name, and save it.

    ![The Save icon is selected, and from its drop-down menu, the new graph is named Engine temp perspective, and is set to Share this Perspective.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image174.png 'Save icon')

8.  Now any users who have access to the Time Series Insights environment can view your saved Perspective.

## After the hands-on lab

**Duration:** 10 minutes

In this exercise, attendees will deprovision any Azure resources that were created in support of the lab.

### Task 1: Deprovision the accelerator through the website

1.  Access the [Azure IoT Accelerators Site](https://www.azureiotsolutions.com/Accelerators).

2.  Log in using your Azure Portal Credentials, then press the **My Solutions** button.

    ![Sign in and access My Solutions.](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image236.png 'Sign in and access My Solutions')

3.  Press the **iot-remote-monitoring** solution card.

    ![IoT Remote Monitoring solution](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image237.png 'IoT Remote Monitoring solution')

4.  Press the **Delete Solution** button.

    ![Delete solution](images/Hands-onlabstep-by-step-IoTandtheSmartCityimages/media/image238.png 'Delete solution')

### Task 2: Delete the Resource group in which you placed your Azure resources

1.  From the Portal, navigate to the blade of your Resource Group and select Delete in the command bar at the top.

2.  Confirm the deletion by re-typing the resource group name and selecting Delete.

You should follow all steps provided _after_ attending the hands-on lab.

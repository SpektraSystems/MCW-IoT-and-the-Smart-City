﻿// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.Azure.IoTSolutions.StorageAdapter.WebService.v1
{
    /// <summary>Web service API version 1 information</summary>
    public static class Version
    {
        /// <summary>Number used for routing HTTP requests</summary>
        public const string Number = "1";

        /// <summary>Full path used in the URL</summary>
        public const string Path = "v" + Number;

        /// <summary>Date when the API version has been published</summary>
        public const string Date = "201706";
    }
}

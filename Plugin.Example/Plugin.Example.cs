﻿// <copyright file="Plugin.Example.cs" company="David Wallis">
// Copyright (c) David Wallis. All rights reserved.
// </copyright>

using System.ComponentModel.Composition;
using Plugin.Example.Logging;
using Plugin.Interface;

namespace Plugin.Example
{

    [Export(typeof(IPlugin))]
    public class ExamplePlugin : IPlugin
    {
        private static readonly ILog Logger = LogProvider.For<ExamplePlugin>();

        public string Description => "Plugin Example";

        public Status Status { get; set; }

        [Import]
        public ISomething something { get; set; }

        public void Start(string message)
        {
            Logger.Info("Plugin Starting");

            var test = new TimerTest();
            test.StartTimer();

            this.something.DoSomething("a value blah");
        }

    }
}

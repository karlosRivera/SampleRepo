﻿using System;
using System.Timers;
using SkypeAutoRecorder.Core.SkypeApi;
using SkypeAutoRecorder.Core.WinApi;

namespace SkypeAutoRecorder.Core
{
    internal partial class SkypeConnector
    {
        /// <summary>
        /// Class name of the Skype window that actually allows attaching and send event messages to applications.
        /// </summary>
        private const string SkypeMainWindowClass = "tSkMainForm";
        
        /// <summary>
        /// Login window of the Skype that doesn't provide API.
        /// </summary>
        private const string SkypeLoginWindowClass = "TLoginForm";

        /// <summary>
        /// Periodicity of checking that Skype is still working (in ms).
        /// </summary>
        private const double WatchInterval = 1000;

        /// <summary>
        /// Last time when PONG was recieved from Skype.
        /// </summary>
        private DateTime _lastPong;

        private readonly Timer _skypeWatcher;

        private void skypeWatcherHandler(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            // Check that Skype window that provides API is active now.
            var skypeIsActive = WinApiWrapper.WindowExists(SkypeMainWindowClass) &&
                                !WinApiWrapper.WindowExists(SkypeLoginWindowClass);

            // Ping-pong with Skype to check if we still are subscribed to its messages.
            if (IsConnected && skypeIsActive)
            {
                sendSkypeCommand(SkypeCommands.Ping);
                
                // Check when last PONG was recieved. Let 3 lost PONGs are OK.
                var diff = DateTime.Now - _lastPong;
                if (diff.Milliseconds > WatchInterval * 3)
                {
                    disconnect();
                    return;
                }
            }

            if (!IsConnected && skypeIsActive)
            {
                enableSkypeMessaging();
            }
            else if (IsConnected && !skypeIsActive)
            {
                disconnect();
            }
        }

        private void enableSkypeMessaging()
        {
            // Register API messages for communicating with Skype.
            _skypeApiDiscover = WinApiWrapper.RegisterApiMessage(SkypeControlApiMessages.Discover);
            _skypeApiAttach = WinApiWrapper.RegisterApiMessage(SkypeControlApiMessages.Attach);

            // Register Skype messages handler if Skype is active.
            WinApiWrapper.SendMessage(BroadcastHandle, _skypeApiDiscover, _windowHandleSource.Handle);
        }
    }
}

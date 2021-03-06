﻿////////////////////////////////////////////////////////////////////////////////
//
//  IDEUM
//  Copyright 2011-2013 Ideum
//  All Rights Reserved.
//
//  Gestureworks Core
//
//  File:     GesturePhase.cs
//  Authors:  Ideum
//
//  NOTICE: Ideum permits you to use, modify, and distribute this file only
//  in accordance with the terms of the license agreement accompanying it.
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestureWorksCoreNET
{
    /// <summary>
    /// The GesturePhase describes the current state of the gesture and is consumable via the <see cref="GestureEvent.Phase"/> property.
    /// </summary>
    public enum GesturePhase
    {
        /// <summary>
        /// Signifies the start of a gesture.
        /// </summary>
        GESTURE_BEGIN = 0,

        /// <summary>
        /// The gesture is currently being generated by direct manipulation.
        /// </summary>
        GESTURE_ACTIVE = 1,
        
        /// <summary>
        /// Direct manipulation has ceased.
        /// </summary>
        GESTURE_RELEASE = 2,
        
        /// <summary>
        /// The gesture is being generated by indirect manipulation (e.g. inertial filters).
        /// </summary>
        GESTURE_PASSIVE = 3,
        
        /// <summary>
        /// The gesture has completed; this is the last event in a gesture's lifespan.
        /// </summary>
        GESTURE_END = 4
    }
}

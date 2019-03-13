// Copyright (c) Microsoft. All rights reserved.

/*global log*/
/*jslint node: true*/

"use strict";

var center_latitude = 40.696798;
var center_longitude = -73.956592;

// Default state
var state = {
    online: true,
    latitude: center_latitude,
    longitude: center_longitude,
    timing: 65.0,
    timing_unit: "seconds",
    state: 3,
    voltage: 68.4,
    serial_number: "PYTGN22694"
};

/**
 * Restore the global state using data from the previous iteration.
 *
 * @param previousState The output of main() from the previous iteration
 */
function restoreState(previousState) {
    // If the previous state is null, force a default state
    if (previousState !== undefined && previousState !== null) {
        state = previousState;
    } else {
        log("Using default state");
    }
}

/**
 * Simple formula generating a random value around the average
 * in between min and max
 */
function vary(avg, percentage, min, max) {
    var value = avg * (1 + ((percentage / 100) * (2 * Math.random() - 1)));
    value = Math.max(value, min);
    value = Math.min(value, max);
    return value;
}

/**
 * Traffic light state could be:
 * 1: Green
 * 2: Yellow
 * 3: Red
 */
function varystate(current, min, max) {
    if (current === min) {
        return current + 1;
    }
    if (current === max) {
        return current - 1;
    }
    if (Math.random() < 0.5) {
        return current - 1;
    }
    return current + 1;
}

/**
 * Entry point function called by the simulation engine.
 *
 * @param context        The context contains current time, device model and id
 * @param previousState  The device state since the last iteration
 */
/*jslint unparam: true*/
function main(context, previousState) {

    // Restore the global state before generating the new telemetry, so that
    // the telemetry can apply changes using the previous function state.
    restoreState(previousState);

    // Min 1, Max 3
    state.state = varystate(state.state, 1, 3);

    // 68.4 +/- 25%,  Min 57.5, Max 83.48
    state.voltage = vary(68.4, 25, 57.5, 83.48);

    return state;
}

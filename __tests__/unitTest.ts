import {RiceCooker} from "../RiceCookerType";
import { cancel } from "../components/Cancel";
import { setCookingMode } from "../components/CookingMode";
import plugIn from "../components/PluggedIn";
import { powerOn } from "../components/PowerOn";
import { unplug } from "../components/UnpluggedIn";

describe('Rice cooker unit test', () => {
    let cooker: RiceCooker;

    beforeEach(() => {
        cooker = {
            powerOn: false,
            cooking: false,
            cookingTime: 0,
            pluggedIn: false,
        }
    });

    test('pluggedIn should be true when rice cooker is plug in' , () => {
        plugIn(cooker);
        expect(cooker.pluggedIn).toBeTruthy();
    });

    test('pluggedIn and powerOn should be false when rice cooker is unplug' , () => {
        plugIn(cooker);
        powerOn(cooker);
        unplug(cooker);
        expect(cooker.pluggedIn).toBeFalsy();
        expect(cooker.powerOn).toBeFalsy();
    });

    test('If rice cooker plugged in and power on, powerOn should be true', () => {
        plugIn(cooker);
        powerOn(cooker);
        expect(cooker.powerOn).toBeTruthy();
    });

    test('If power on is true, setCookingMode should set mode coooking with time',() => {
        plugIn(cooker);
        powerOn(cooker);
        setCookingMode(cooker, 30);
        expect(cooker.cooking).toBeTruthy();
        expect(cooker.cookingTime).toBe(30);
    });

    test('All modes and time should reset',() => {
        cancel(cooker);
        expect(cooker.cooking).toBeFalsy();
    })
})
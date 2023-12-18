import { RiceCooker } from "../RiceCookerType";

export function powerOn(cooker: RiceCooker): void {
    if (cooker.pluggedIn) {
      cooker.powerOn = true;
      console.log('The rice cooker is turned on.');
    } else {
      console.log('Please plug in the rice cooker before turning it on.');
    }
}
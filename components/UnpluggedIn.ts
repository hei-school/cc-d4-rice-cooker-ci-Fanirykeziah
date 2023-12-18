import { RiceCooker } from "../RiceCookerType";

export function unplug(cooker: RiceCooker): void {
    cooker.pluggedIn = false;
    cooker.powerOn = false;
    console.log('The rice cooker is unplugged.');
}
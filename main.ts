import { cancel } from "./components/Cancel";
import { setCookingMode } from "./components/CookingMode";
import plugIn from "./components/PluggedIn";
import { powerOn } from "./components/PowerOn";
import { unplug } from "./components/UnpluggedIn";

interface RiceCooker {
    powerOn: boolean;
    cooking: boolean;
    cookingTime: number;
    pluggedIn: boolean;
  }
  
  const cooker: RiceCooker = {
    powerOn: false,
    cooking: false,
    cookingTime: 0,
    pluggedIn: false,
  };
  
  try {
    plugIn(cooker);
    powerOn(cooker);
    setCookingMode(cooker, 30);
    cancel(cooker);
  } catch (error) {
    console.log(error);
  } finally {
    unplug(cooker);
  }
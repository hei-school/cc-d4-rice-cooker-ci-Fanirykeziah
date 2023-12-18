def plug_in(cooker):
    cooker['plugged_in'] = True
    print('The rice cooker is plugged in.')

def unplug(cooker):
    cooker['plugged_in'] = False
    cooker['power_on'] = False
    print('The rice cooker is unplugged.')

def power_on(cooker):
    if cooker['plugged_in']:
        cooker['power_on'] = True
        print('The rice cooker is turned on.')
    else:
        print('Please plug in the rice cooker before turning it on.')

def set_cooking_mode(cooker, time):
    if not cooker['power_on']:
        raise Exception('The rice cooker must be turned on before setting the cooking mode.')

    cooker['cooking'] = True
    cooker['cooking_time'] = time
    print(f"The rice cooker is in automatic cooking mode for {time} minutes.")

def set_warm_mode(cooker, time):
    if not cooker['power_on']:
        raise Exception('The rice cooker must be turned on before setting the warm mode.')

    cooker['warm_mode'] = True
    cooker['warm_time'] = time
    print(f"The rice cooker is in warm mode for {time} minutes.")

def set_steam_mode(cooker, time, steam_level):
    if not cooker['power_on']:
        raise Exception('The rice cooker must be turned on before setting the steam cooking mode.')

    cooker['steam_mode'] = True
    cooker['steam_time'] = time
    print(f"The rice cooker is in steam cooking mode at level {steam_level} for {time} minutes.")

def cancel(cooker):
    cooker['cooking'] = False
    cooker['warm_mode'] = False
    cooker['steam_mode'] = False
    cooker['cooking_time'] = 0
    cooker['warm_time'] = 0
    cooker['steam_time'] = 0
    print('All operations have been canceled.')

def power_on(cooker):
    if not cooker['plugged_in']:
        raise Exception('Please plug in the rice cooker before turning it on.')
    else:
        cooker['power_on'] = True

cooker = {
    'power_on': False,
    'cooking': False,
    'warm_mode': False,
    'steam_mode': False,
    'cooking_time': 0,
    'warm_time': 0,
    'steam_time': 0,
    'plugged_in': False
}

try:
    plug_in(cooker)
    power_on(cooker)
    set_cooking_mode(cooker, 30)
    set_warm_mode(cooker, 60)
    set_steam_mode(cooker, 60, 200)
    cancel(cooker)
except Exception as e:
    print(e)
finally:
    unplug(cooker)

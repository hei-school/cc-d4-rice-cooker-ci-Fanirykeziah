import unittest
from RiceCooker import power_on
from RiceCooker import (
    plug_in,
    unplug,
    # power_on,
    set_cooking_mode,
    set_warm_mode,
    set_steam_mode,
    cancel,
)

class RiceCookerTest(unittest.TestCase):
    def setUp(self):
        self.cooker = {
            'power_on': False,
            'cooking': False,
            'warm_mode': False,
            'steam_mode': False,
            'cooking_time': 0,
            'warm_time': 0,
            'steam_time': 0,
            'plugged_in': False
        }

    def tearDown(self):
        unplug(self.cooker)

    def test_plug_in(self):
        plug_in(self.cooker)
        self.assertTrue(self.cooker['plugged_in'])
        self.assertFalse(self.cooker['power_on'])

    def test_unplug(self):
        plug_in(self.cooker)
        unplug(self.cooker)
        self.assertFalse(self.cooker['plugged_in'])
        self.assertFalse(self.cooker['power_on'])

    def test_power_on(self):
        with self.assertRaises(Exception):
            power_on(self.cooker)

        plug_in(self.cooker)
        power_on(self.cooker)
        self.assertTrue(self.cooker['power_on'])

    def test_set_cooking_mode(self):
        with self.assertRaises(Exception):
            set_cooking_mode(self.cooker, 30)

        plug_in(self.cooker)
        power_on(self.cooker)
        set_cooking_mode(self.cooker, 30)
        self.assertTrue(self.cooker['cooking'])
        self.assertEqual(self.cooker['cooking_time'], 30)

    def test_set_warm_mode(self):
        with self.assertRaises(Exception):
            set_warm_mode(self.cooker, 60)

        plug_in(self.cooker)
        power_on(self.cooker)
        set_warm_mode(self.cooker, 60)
        self.assertTrue(self.cooker['warm_mode'])
        self.assertEqual(self.cooker['warm_time'], 60)

    def test_set_steam_mode(self):
        with self.assertRaises(Exception):
            set_steam_mode(self.cooker, 60, 200)

        plug_in(self.cooker)
        power_on(self.cooker)
        set_steam_mode(self.cooker, 60, 200)
        self.assertTrue(self.cooker['steam_mode'])
        self.assertEqual(self.cooker['steam_time'], 60)

    def test_cancel(self):
        plug_in(self.cooker)
        power_on(self.cooker)
        set_cooking_mode(self.cooker, 30)
        set_warm_mode(self.cooker, 60)
        set_steam_mode(self.cooker, 60, 200)
        cancel(self.cooker)
        self.assertFalse(self.cooker['cooking'])
        self.assertFalse(self.cooker['warm_mode'])
        self.assertFalse(self.cooker['steam_mode'])
        self.assertEqual(self.cooker['cooking_time'], 0)
        self.assertEqual(self.cooker['warm_time'], 0)
        self.assertEqual(self.cooker['steam_time'], 0)

if __name__ == '__main__':
    unittest.main()
// <copyright file="IRiceCooker.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

#pragma warning disable SA1600 // Elements should be documented
internal interface IRiceCooker
#pragma warning restore SA1600 // Elements should be documented
{
#pragma warning disable SA1600 // Elements should be documented
    bool PowerOn { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    bool Cooking { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    bool WarmMode { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    bool SteamMode { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    int CookingTime { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    int WarmTime { get; set; }
#pragma warning restore SA1600 // Elements should be documented

#pragma warning disable SA1600 // Elements should be documented
    int SteamTime { get; set; }

#pragma warning restore SA1600 // Elements should be documented
#pragma warning disable SA1600 // Elements should be documented
    bool PluggedIn { get; set; }
#pragma warning restore SA1600 // Elements should be documented
}

#pragma warning disable SA1600 // Elements should be documented
internal class RiceCooker : IRiceCooker
#pragma warning restore SA1600 // Elements should be documented
{
    /// <inheritdoc/>
    public bool PowerOn { get; set; }

    /// <inheritdoc/>
    public bool Cooking { get; set; }

    /// <inheritdoc/>
    public bool WarmMode { get; set; }

    /// <inheritdoc/>
    public bool SteamMode { get; set; }

    /// <inheritdoc/>
    public int CookingTime { get; set; }

    /// <inheritdoc/>
    public int WarmTime { get; set; }

    /// <inheritdoc/>
    public int SteamTime { get; set; }

    /// <inheritdoc/>
    public bool PluggedIn { get; set; }
}

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1600 // Elements should be documented
internal class Program
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1402 // File may only contain a single type
{
    private static void Main(string[] args)
    {
        IRiceCooker cooker = new RiceCooker();

        try
        {
            PlugIn(cooker);
            PowerOn(cooker);
            SetCookingMode(cooker, 30);
            SetWarmMode(cooker, 60);
            SetSteamMode(cooker, 60, 200);
            Cancel(cooker);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Unplug(cooker);
        }
    }

    private static void PlugIn(IRiceCooker cooker)
    {
        cooker.PluggedIn = true;
        Console.WriteLine("The rice cooker is plugged in.");
    }

    private static void Unplug(IRiceCooker cooker)
    {
        cooker.PluggedIn = false;
        cooker.PowerOn = false;
        Console.WriteLine("The rice cooker is unplugged.");
    }

    private static void PowerOn(IRiceCooker cooker)
    {
        if (cooker.PluggedIn)
        {
            cooker.PowerOn = true;
            Console.WriteLine("The rice cooker is turned on.");
        }
        else
        {
            Console.WriteLine("Please plug in the rice cooker before turning it on.");
        }
    }

    private static void SetCookingMode(IRiceCooker cooker, int time)
    {
        try
        {
            if (!cooker.PowerOn)
            {
                throw new Exception("The rice cooker must be turned on before setting the cooking mode.");
            }

            cooker.Cooking = true;
            cooker.CookingTime = time;
            Console.WriteLine($"The rice cooker is in automatic cooking mode for {time} minutes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SetWarmMode(IRiceCooker cooker, int time)
    {
        try
        {
            if (!cooker.PowerOn)
            {
                throw new Exception("The rice cooker must be turned on before setting the warm mode.");
            }

            cooker.WarmMode = true;
            cooker.WarmTime = time;
            Console.WriteLine($"The rice cooker is in warm mode for {time} minutes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SetSteamMode(IRiceCooker cooker, int time, int steamLevel)
    {
        try
        {
            if (!cooker.PowerOn)
            {
                throw new Exception("The rice cooker must be turned on before setting the steam cooking mode.");
            }

            cooker.SteamMode = true;
            cooker.SteamTime = time;
            Console.WriteLine($"The rice cooker is in steam cooking mode at level {steamLevel} for {time} minutes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Cancel(IRiceCooker cooker)
    {
        cooker.Cooking = false;
        cooker.WarmMode = false;
        cooker.SteamMode = false;
        cooker.CookingTime = 0;
        cooker.WarmTime = 0;
        cooker.SteamTime = 0;
        Console.WriteLine("All operations have been canceled.");
    }
}
# frozen_string_literal: true

class RiceCooker
    attr_accessor :power_on, :cooking, :warm_mode, :steam_mode,
                  :cooking_time, :warm_time, :steam_time, :plugged_in
  
    def initialize(power_on, cooking, warm_mode, steam_mode,
                   cooking_time, warm_time, steam_time, plugged_in)
      @power_on = power_on
      @cooking = cooking
      @warm_mode = warm_mode
      @steam_mode = steam_mode
      @cooking_time = cooking_time
      @warm_time = warm_time
      @steam_time = steam_time
      @plugged_in = plugged_in
    end
  
    def plug_in
      @plugged_in = true
      puts 'The rice cooker is plugged in.'
    end
  
    def unplug
      @plugged_in = false
      @power_on = false
      puts 'The rice cooker is unplugged.'
    end
  
    def power_on
      if @plugged_in
        @power_on = true
        puts 'The rice cooker is turned on.'
      else
        puts 'Please plug in the rice cooker before turning it on.'
      end
    end
  
    def set_cooking_mode(time)
      unless @power_on
        raise 'The rice cooker must be turned on before setting the cooking mode.'
      end
  
      @cooking = true
      @cooking_time = time
      puts "The rice cooker is in automatic cooking mode for #{time} minutes."
    rescue StandardError => e
      puts e
    end
  
    def set_warm_mode(time)
      unless @power_on
        raise 'The rice cooker must be turned on before setting the warm mode.'
      end
  
      @warm_mode = true
      @warm_time = time
      puts "The rice cooker is in warm mode for #{time} minutes."
    rescue StandardError => e
      puts e
    end
  
    def set_steam_mode(time, steam_level)
      unless @power_on
        raise 'The rice cooker must be turned on before setting the steam cooking mode.'
      end
  
      @steam_mode = true
      @steam_time = time
      puts "The rice cooker is in steam cooking mode at level #{steam_level} for #{time} minutes."
    rescue StandardError => e
      puts e
    end
  
    def cancel
      @cooking = false
      @warm_mode = false
      @steam_mode = false
      @cooking_time = 0
      @warm_time = 0
      @steam_time = 0
      puts 'All operations have been canceled.'
    end
  end
  
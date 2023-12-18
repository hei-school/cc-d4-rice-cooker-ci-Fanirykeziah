require_relative 'rice_cooker' # Assurez-vous que le chemin d'accès est correct

require 'rspec'

RSpec.describe 'RiceCooker' do 
    let(:cooker) { RiceCooker.new(false, false, false, false, 0, 0, 0, false) }

    describe '#plug-in' do 
      it 'shloud set plugged_in to true' do 
        plug_in(cooker)
        expect(cooker.plugged_in).to eq(true)

      end
    end

    describe '#unplug' do
        it 'should set plugged_in and power_on to false' do
            unplug(cooker)
            expect(cooker.plugged_in).to eq(false)
            expect(cooker.power_on).to eq(false)
        end
     end
    
    describe '#power_on' do
        it 'If rice cooker plugged in and power on, power_on should be true' do
            plug_in(cooker)
            power_on(cooker)
            expect(cooker.power_on).to eq(true)
        end
    end

    describe '#set_cooking_mode' do
        it 'If power on is true, set_cooking_mode should set mode coooking with time' do
            plug_in(cooker);
            power_on(cooker);
            set_cooking_mode(cooker, 30);
            expect(cooker.cooking).to eq(true);
        end
    end

    describe '#set_warm_mode' do
        it 'If power on is true, set_warm_mode should set warm mode with time' do
            plug_in(cooker);
            power_on(cooker);
            set_cooking_mode(cooker, 30);
            expect(cooker.warm_mode).to eq(true);
        end
    end

    describe '#set_steam_mode' do
        it 'set_steam_mode should set to steam mode with time and level if rice cooker is power on' do
            plug_in(cooker);
            power_on(cooker);
            set_steam_mode(cooker, 30);
            expect(cooker.steam_mode).to eq(true);
        end
    end

    describe '#cancel' do
        it 'All modes and time should reset' do
            cancel(cooker);
            expect(cooker.cooking).to eq(false);
            expect(cooker.steam_mode).to eq(false);
            expect(cooker.warm_mode).to eq(false);
        end
    end
end
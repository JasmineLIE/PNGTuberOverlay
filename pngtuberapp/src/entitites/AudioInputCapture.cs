using Godot;
using System;

public partial class AudioInputCapture : Node
{

    AudioStreamPlayer2D MicInput = null;
    AudioEffectRecord AudioEffect;
    private int MicInputBusIndex;
    public static int ClampMAX = -50;
    public static int ClampMIN = -30;
    
    public override void _Ready()
    {
        MicInput = GetNode<AudioStreamPlayer2D>("MicInputListener");

        MicInputBusIndex = AudioServer.GetBusIndex("MicInput");
     
      
    }


    public float ReturnMicVal()
    {
        float peakVolumeDb = AudioServer.GetBusPeakVolumeLeftDb(MicInputBusIndex, 0);
        float clamp = Mathf.Clamp(peakVolumeDb, ClampMAX, ClampMIN); //Any speaking value should be greater than -60
        GD.Print(clamp);
        return clamp;
    }
}

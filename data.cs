// DISTANT SHOTS //

datablock AudioDescription(RPX_Distant : HeavyFar3D)
{
	volume = 0.75;
};

datablock AudioProfile(RPX_PistolDistFireSound)
{
	filename    = "./wav/dist_Pistol.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

datablock AudioProfile(RPX_SMGDistFireSound)
{
	filename    = "./wav/dist_Submachine.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

datablock AudioProfile(RPX_MarksmanDistFireSound)
{
	filename    = "./wav/dist_Marksman.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

datablock AudioProfile(RPX_RifleDistFireSound)
{
	filename    = "./wav/dist_AssaultRifle.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

datablock AudioProfile(RPX_ShotgunDistFireSound)
{
	filename    = "./wav/dist_Shotgun.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

datablock AudioProfile(RPX_SniperDistFireSound)
{
	filename    = "./wav/dist_SniperRifle.wav";
	description = RPX_Distant;
	pitchRange = 25;
	preload = true;
};

// UNHOLSTER //

datablock AudioProfile(RPX_ShotgunUnholsterSound)
{
	filename    = "./wav/unholster_shotgun.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_RifleUnholsterSound)
{
	filename    = "./wav/unholster_rifle.wav"; // TODO
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_SMGUnholsterSound)
{
	filename    = "./wav/unholster_smg.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_PistolUnholsterSound)
{
	filename    = "./wav/unholster_pistol.wav"; // TODO
	description = AudioClosest3D;
	preload = true;
};
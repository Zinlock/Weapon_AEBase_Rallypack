datablock AudioProfile(RPX_B828Fire1Sound)
{
	filename    = "./wav/B828_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_B828Fire2Sound)
{
	filename    = "./wav/B828_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_B828Fire3Sound)
{
	filename    = "./wav/B828_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_B828ReloadOpenSound)
{
	filename    = "./wav/B828_reload_open.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_B828ReloadEndSound)
{
	filename    = "./wav/B828_reload.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_B828Reload2OpenSound)
{
	filename    = "./wav/B828_reload_emptyopen.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_B828Reload2EndSound)
{
	filename    = "./wav/B828_reload_empty.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock ItemData(RPX_B828Item)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/B828_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: Benelli 828";
	iconName = "./icon/828";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_B828Image;
	canDrop = true;

	AEAmmo = 2;
	AEType = AE_LightSAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "Heavy";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_B828Image)
{
	shapeFile = "./dts/B828_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0.1 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_B828Item;
	ammo = " ";

	// scopingImage = RPX_B828ScopeImage;

	casing = AE_BEShotgunShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_B828Item.colorShiftColor;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 14;
	projectileCount = 8;
	projectileHeadshotMult = 1.2;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	recoilHeight = 6;
	recoilWidth = 0;
	recoilWidthMax = 0;
	recoilHeightMax = 25;

	spreadBurst = 1;
	spreadBase = 450;
	spreadReset = 700;
	spreadMin = 550;
	spreadMax = 700;

	screenshakeMin = "0.02 0.02 0.02";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = RPX_ShotgunDistFireSound;
	farShotDistance = 40;

	sonicWhizz = true;
	whizzSupersonic = false;
	whizzThrough = false;
	whizzDistance = 10;
	whizzChance = 20;
	whizzAngle = 80;

	projectileFalloffStart = $ae_falloffShotgunStart;
	projectileFalloffEnd = $ae_falloffShotgunEnd;
	projectileFalloffDamage = $ae_falloffShotgun;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.4;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "unholster";
	stateSound[0]					= RPX_RifleUnholsterSound;

	stateName[1]                     	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]       	= "ReloadStart";
	stateTransitionOnTriggerDown[1]  	= "preFire";
	stateAllowImageChange[1]         	= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireLoadCheckA";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[4]				= "FireLoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.2;
	stateTransitionOnTimeout[4]		= "SemiAutoCheck";
	
	stateName[5]				= "FireLoadCheckB";
	stateTransitionOnAmmo[5]		= "Ready";
	stateTransitionOnNoAmmo[5]		= "Reload2Start";
	stateTransitionOnNotLoaded[5]  = "Ready";

	stateName[14]				= "LoadCheckA";
	stateScript[14]				= "AEMagLoadCheck";
	stateTimeoutValue[14]			= 0.1;
	stateTransitionOnTimeout[14]		= "LoadCheckB";
	
	stateName[15]				= "LoadCheckB";
	stateTransitionOnAmmo[15]		= "Ready";
	stateTransitionOnNotLoaded[15] = "Empty";
	stateTransitionOnNoAmmo[15]		= "Reload2Start";

	stateName[16]				= "ReloadStart";
	stateTimeoutValue[16]			= 0.5;
	stateScript[16]				= "onReloadStart";
	stateTransitionOnTimeout[16]		= "Reload";
	stateWaitForTimeout[16]			= true;
	stateSequence[16]			= "ReloadStart";
	
	stateName[17]				= "Reload";
	stateTimeoutValue[17]			= 1.3;
	stateScript[17]				= "onReload";
	stateTransitionOnTimeout[17]		= "ReloadEnd";
	stateWaitForTimeout[17]			= true;
	stateSequence[17]			= "Reload";
	
	stateName[19]				= "ReloadEnd";
	stateTimeoutValue[19]			= 0.1;
	stateScript[19]				= "AEMagReloadAll";
	stateTransitionOnTimeout[19]		= "Ready";
	stateWaitForTimeout[19]			= true;
	stateSequence[19]			= "ReloadEnd";
		
	stateName[20]				= "Reloaded";
	stateTimeoutValue[20]			= 0.1;
	stateScript[20]				= "AEMagReloadAll";
	stateTransitionOnTimeout[20]		= "Ready";

	stateName[21]				= "Reload2Start";
	stateTimeoutValue[21]			= 0.4;
	stateScript[21]				= "onReload2Start";
	stateTransitionOnTimeout[21]		= "Reload2";
	stateWaitForTimeout[21]			= true;
	stateSequence[21]			= "ReloadStartEmpty";

	stateName[22]				= "Reload2";
	stateTimeoutValue[22]			= 1.7;
	stateScript[22]				= "onReload2";
	stateTransitionOnTimeout[22]		= "Reload2End";
	stateWaitForTimeout[22]			= true;
	stateSequence[22]			= "ReloadEmpty";

	stateName[24]				= "Reload2End";
	stateTimeoutValue[24]			= 0.1;
	stateScript[24]				= "AEMagReloadAll";
	stateTransitionOnTimeout[24]		= "Ready";
	stateWaitForTimeout[24]			= true;
	stateSequence[24]			= "ReloadEndEmpty";

	stateName[26]          = "Empty";
	stateTransitionOnTriggerDown[26]  = "Dryfire";
	stateTransitionOnLoaded[26] = "Reload2Start";
	stateScript[26]        = "AEOnEmpty";

	stateName[27]           = "Dryfire";
	stateTransitionOnTriggerUp[27] = "Empty";
	stateWaitForTimeout[27]    = false;
	stateScript[27]      = "onDryFire";
	
	stateName[28]           = "SemiAutoCheck";
	stateTransitionOnTriggerUp[28]	  	= "FireLoadCheckB";
};

function RPX_B828Image::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_B828Fire @ getRandom(1, 3) @ Sound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_B828Image::onReloadStart(%this, %obj, %slot)
{
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_B828ReloadOpenSound);
}

function RPX_B828Image::onReload(%this, %obj, %slot)
{	
	%obj.stopAudio(1);
	%obj.playAudio(1, RPX_B828ReloadEndSound);
	// %obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	// %obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_B828ReloadInsertSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload6Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEShellShotgun @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_B828Image::onReload2Start(%this, %obj, %slot)
{
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_B828Reload2OpenSound); // todo? different empty open sound
}

function RPX_B828Image::onReload2(%this, %obj, %slot)
{
	%obj.stopAudio(1);
	%obj.playAudio(1, RPX_B828Reload2EndSound);
	// %obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	// %obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_B828ReloadMagInSound);

	// %obj.reload4Schedule = %obj.schedule(1000, stopAudio, 2);
	// %obj.reload5Schedule = %obj.schedule(1000, playAudio, 2, RPX_B828ReloadEndEmptySound);

	%this.onMagDrop(%obj,%slot, true);
	%obj.reload5Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEShellShotgun @ getRandom(1,3) @ Sound,%obj.getPosition());
	%obj.reload6Schedule = schedule(getRandom(400,500),0,serverPlay3D,AEShellShotgun @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_B828Image::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_B828Image::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_B828Image::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_B828Image::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reload0Schedule);
	cancel(%obj.reload1Schedule);
	cancel(%obj.reload2Schedule);
	cancel(%obj.reload3Schedule);
	cancel(%obj.reload4Schedule);
	cancel(%obj.reload5Schedule);
	cancel(%obj.reload6Schedule);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_B828Image::onMagDrop(%this,%obj,%slot, %empty)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));

	if(%empty)
	{
		%a.mountImage(RPX_B828MagEmptyImage,0);

		%a = new Camera()
		{
			datablock = Observer;
			position = %obj.getPosition();
			scale = "1 1 1";
		};

		%pos = vectorAdd(%obj.getSlotTransform(0), vectorScale(%obj.getUpVector(), -0.25));
		%a.setTransform(%pos SPC getWords(%obj.getSlotTransform(0), 3, 6));

		%a.mountImage(RPX_B828MagEmptyImage,0);
	}
	else
		%a.mountImage(RPX_B828MagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_B828MagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.214 0.632 0.415";
	rotation = eulerToMatrix( "-50 -15 0" );
	
	casing = AE_BEShotgunShellDebris;
	shellExitDir        = "-0.25 -1.0 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 9.0;
	shellVelocity       = 3.0;
	
	stateName[0]                    = "Ready";
	stateTimeoutValue[0]            = 0.01;
	stateTransitionOnTimeout[0]     = "EjectA";
	
	stateName[1]                    = "EjectA";
	stateEjectShell[1]                = true;
	stateTimeoutValue[1]            = 1;
	stateTransitionOnTimeout[1]     = "Done";
	
	stateName[2]                    = "Done";
	stateScript[2]                    = "onDone";
};

datablock ShapeBaseImageData(RPX_B828MagEmptyImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "0.157 0.557 0.328";
	rotation = eulerToMatrix( "-40 15 0" );

	casing = AE_BEShotgunShellDebris;
	shellExitDir        = "0.25 -1.0 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 9.0;
	shellVelocity       = 3.0;
	
	stateName[0]                    = "Ready";
	stateTimeoutValue[0]            = 0.01;
	stateTransitionOnTimeout[0]     = "EjectA";
	
	stateName[1]                    = "EjectA";
	stateEjectShell[1]                = true;
	stateTimeoutValue[1]            = 1;
	stateTransitionOnTimeout[1]     = "Done";
	
	stateName[2]                    = "Done";
	stateScript[2]                    = "onDone";
};

function RPX_B828MagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

// RPXGenerateADSImage(RPX_B828ScopeImage, RPX_B828Image,
//                     "0 0.7 -0.72", eulerToMatrix("0 -30 0"),
// 										$ae_MedScopeFOV, 0,
// 										16, 21,
// 										"R_MovePenalty = 0.5;" NL
// 										"stateTimeoutValue[0] = 0.3;" NL
// 										"stateSound[0] = \"\";" NL
// 										"stateSequence[0] = \"scopeIn\";" NL
// 										"stateSequence[3] = \"fireADS\";",
// 										AEAdsIn1Sound, AEAdsOut1Sound,
// 										0.25, 0.25,
// 										0.25, 0.25,
// 										0.2);

// RPXGenerateEquipImage(RPX_B828EquipImage, RPX_B828Image, 0.4, "unholster", RPX_RifleUnholsterSound);
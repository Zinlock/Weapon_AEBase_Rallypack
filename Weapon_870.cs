datablock AudioProfile(RPX_M870Fire1Sound)
{
	filename    = "./wav/870_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_M870Fire2Sound)
{
	filename    = "./wav/870_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_M870Fire3Sound)
{
	filename    = "./wav/870_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_M870PumpBackSound)
{
	filename    = "./wav/870_pump_back.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_M870PumpForwardSound)
{
	filename    = "./wav/870_pump_forward.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock ItemData(RPX_M870Item)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/870_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: 870 MCS";
	iconName = "./icon/870";
	doColorShift = true;
	colorShiftColor = "0.75 0.75 0.75 1";

	image = RPX_M870Image;
	canDrop = true;
	
	AEAmmo = 5;
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

datablock ShapeBaseImageData(RPX_M870Image)
{
	shapeFile = "./dts/870_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_M870Item;
	ammo = " ";

	casing = AE_BEShotgunShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_M870Item.colorShiftColor;

	muzzleFlashScale = "1.5 1.5 1.5";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 13;
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
	spreadBase = 600;
	spreadReset = 800;
	spreadMin = 700;
	spreadMax = 800;

	screenshakeMin = "0.2 0.2 0.2";
	screenshakeMax = "0.4 0.4 0.4";
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

	stateName[1]                    	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnTriggerDown[1] 	= "preFire";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]		= "ReloadStart";
	stateAllowImageChange[1]		= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateTransitionOnNoAmmo[2]       	= "NoAmmoFlashFix";
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireDelay";
	stateEmitter[3]					= AEBaseSmokeBigEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[4]                    = "FireEmpty";
	stateTransitionOnTimeout[4]     = "FireDelay";
	stateEmitter[4]					= AEBaseSmokeBigEmitter;
	stateEmitterTime[4]				= 0.05;
	stateEmitterNode[4]				= "muzzlePoint";
	stateAllowImageChange[4]        = false;
	stateSequence[4]                = "Fire";
	stateWaitForTimeout[4]			= true;
	
	stateName[5]				= "FireLoadCheckA";
	stateScript[5]				= "AEMagLoadCheck";
	stateTimeoutValue[5]			= 0.06;
	stateTransitionOnTimeout[5]     = "FireLoadCheckB";
	
	stateName[6]				= "FireLoadCheckB";
	stateTransitionOnAmmo[6]		= "Ready";
	stateTransitionOnNoAmmo[6]		= "ReloadStart2";
	stateTransitionOnNotLoaded[6]  = "Ready";	
	
	stateName[7]				= "LoadCheckA";
	stateScript[7]				= "AELoadCheck";
	stateTimeoutValue[7]			= 0.1;
	stateTransitionOnTimeout[7]		= "LoadCheckB";
						
	stateName[8]				= "LoadCheckB";
	stateTransitionOnAmmo[8]		= "Ready";
	stateTransitionOnNotLoaded[8] = "Empty";
	stateTransitionOnNoAmmo[8]		= "ReloadStart2";	

	stateName[9]			  	= "ReloadStart";
	stateScript[9]				= "onReloadStart";
	stateTransitionOnTimeout[9]	  	= "Reload";
	stateTimeoutValue[9]		  	= 0.4;
	stateWaitForTimeout[9]		  	= false;
	stateTransitionOnTriggerDown[9]	= "AnotherAmmoCheck";
	stateSound[9]         = RPX_SPAS12ReloadStartSound;
	stateSequence[9]			= "ReloadStart";
	
	stateName[10]			  	= "Pump";
	stateScript[10]				= "onPump";
	stateTransitionOnTimeout[10]	  	= "FireLoadCheckA";
	stateTimeoutValue[10]		  	= 0.4;
	stateWaitForTimeout[10]		  	= false;
	stateEjectShell[10]                       = true;
	stateSequence[10]			= "Pump";
	
	stateName[11]			  	= "ReloadStart2";
	stateScript[11]				= "onReloadStart2";
	stateTransitionOnTimeout[11]	  	= "ReloadStart2B";
	stateTimeoutValue[11]		  	= 1.6;
	stateSequence[11]			= "ReloadEmpty";
	stateScript[11]				= "onReloadStart2";
	stateWaitForTimeout[11]		  	= true;
	
	stateName[12]				= "ReloadStart2B";
	stateScript[12]				= "AEShotgunAltLoadCheck";
	stateTimeoutValue[12]			= 0.05;
	stateWaitForTimeout[12]		  	= false;
	stateTransitionOnTriggerDown[12]	= "AnotherAmmoCheck";
	stateTransitionOnTimeout[12]	  	= "ReloadStart";
	stateTransitionOnNotLoaded[12] = "LoadCheckA";

	stateName[13]				= "Reload";
	stateTransitionOnTimeout[13]     	= "Reloaded";
	stateTransitionOnTriggerDown[13]	= "AnotherAmmoCheck";
	stateWaitForTimeout[13]			= false;
	stateTimeoutValue[13]			= 0.6;
	stateSequence[13]			= "Reload";
	stateSound[13]        = RPX_SPAS12ReloadInSound;
	stateScript[13]				= "LoadEffect";
	
	stateName[14]				= "Reloaded";
	stateTransitionOnTimeout[14]     	= "CheckAmmoA";
	stateTransitionOnTriggerDown[14]	= "AnotherAmmoCheck";
	stateWaitForTimeout[14]			= false;
	
	stateName[15]				= "CheckAmmoA";
	stateScript[15]				= "AEShotgunLoadCheck";
	stateTransitionOnTriggerDown[15]	= "AnotherAmmoCheck";
	stateTransitionOnTimeout[15]		= "CheckAmmoB";	
	
	stateName[16]				= "CheckAmmoB";
	stateTransitionOnTriggerDown[16]	= "AnotherAmmoCheck";
	stateTransitionOnNotLoaded[16]  = "EndReload";
	stateTransitionOnAmmo[16]		= "EndReload";
	stateTransitionOnNoAmmo[16]		= "Reload";
	
	stateName[17]			  	= "EndReload";
	stateTransitionOnTriggerDown[17]	= "AnotherAmmoCheck";
	stateScript[17]				= "onEndReload";
	stateTimeoutValue[17]		  	= 0.5;
	stateSequence[17]			= "ReloadEnd";
	stateSound[17]         = RPX_SPAS12ReloadEndSound;
	stateTransitionOnTimeout[17]	  	= "Ready";
	stateWaitForTimeout[17]		  	= false;

	stateName[18]          = "Empty";
	stateTransitionOnTriggerDown[18]  = "Dryfire";
	stateTransitionOnLoaded[18] = "ReloadStart2";
	stateScript[18]        = "AEOnEmpty";

	stateName[19]           = "Dryfire";
	stateTransitionOnTriggerUp[19] = "Empty";
	stateWaitForTimeout[19]    = false;
	stateScript[19]      = "onDryFire";
	
	stateName[20]           = "AnotherAmmoCheck";
	stateTransitionOnTimeout[20]	  	= "preFire";
	stateScript[20]				= "AELoadCheck";
	
	stateName[22]           = "FireDelay";
	stateTransitionOnTimeout[22] = "SemiAutoCheck";
	stateTimeoutValue[22] = 0.4;
	stateWaitForTimeout[22] = true;

	stateName[21]           = "SemiAutoCheck";
	stateTransitionOnTriggerUp[21]	  	= "Pump";
	
	stateName[30]           = "NoAmmoFlashFix";
	stateTransitionOnTimeout[30] = "FireEmpty";
	stateEmitter[30]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[30]				= 0.05;
	stateEmitterNode[30]				= "muzzlePoint";
};

function RPX_M870Image::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_M870Fire @ getRandom(1, 3) @ Sound);

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_M870Image::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_M870Image::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_M870Image::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_M870Image::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reloadSoundSchedule);
	cancel(%obj.reloadSchedule1);
	cancel(%obj.reloadSchedule2);
	cancel(%obj.reloadSchedule3);
	cancel(%obj.reloadSchedule4);
	cancel(%obj.reloadSchedule5);
	cancel(%obj.reloadSchedule6);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_M870Image::onPump(%this, %obj, %slot)
{
	schedule(getRandom(500,600),0,serverPlay3D,AEShellShotgun @ getRandom(1,3) @ Sound,%obj.getPosition());

	%obj.stopAudio(1);
	%obj.playAudio(1, RPX_M870PumpBackSound);

	%obj.reloadSchedule1 = %obj.schedule(250, stopAudio, 2);
	%obj.reloadSchedule2 = %obj.schedule(250, playAudio, 2, RPX_M870PumpForwardSound);
}

function RPX_M870Image::LoadEffect(%this,%obj,%slot)
{
	%obj.insertshellSchedule = %this.schedule(200,AEShotgunLoadOne,%obj,%slot);
}

function RPX_M870Image::onReloadStart2(%this, %obj, %slot)
{
	RPX_M870Image::LoadEffect(%this, %obj, %slot);

	%obj.stopAudio(1);
	%obj.playAudio(1, RPX_M870PumpBackSound);
	
	%obj.reloadSchedule3 = %obj.schedule(400, stopAudio, 2);
	%obj.reloadSchedule4 = %obj.schedule(400, playAudio, 2, RPX_SPAS12ReloadInSound);

	%obj.reloadSchedule5 = %obj.schedule(900, stopAudio, 1);
	%obj.reloadSchedule6 = %obj.schedule(900, playAudio, 1, RPX_M870PumpForwardSound);
}

function RPX_M870Image::AEShotgunLoadOneEffectless(%this,%obj,%slot)
{
	Parent::AEShotgunLoadOne(%this, %obj, %slot);
}
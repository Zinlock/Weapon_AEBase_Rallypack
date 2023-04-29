function rpx()
{
	exec("./server.cs");
}

$RPX_AR_EffectiveRange = 100;
$RPX_AR_BulletSway = 10.0;
$RPX_AR_BulletDrop = 1.0;
$RPX_AR_BulletSpeed = 600;

$RPX_SR_EffectiveRange = 200;
$RPX_SR_BulletSway = 0.2;
$RPX_SR_BulletDrop = 3.0;
$RPX_SR_BulletSpeed = 1000;

$error = ForceRequiredAddOn("Weapon_AEBase");

if($error == $Error::AddOn_NotFound)
{
	error("ERROR: AEBase_Rallypack - required add-on Weapon_AEBase not found");
}
else
{
	exec("./data.cs");
	exec("./Weapon_Spas12.cs");
	exec("./Weapon_MP5K.cs");
	exec("./Weapon_AK47.cs");
	exec("./Weapon_M4A1.cs");
	exec("./Weapon_92FS.cs");
	exec("./Weapon_Glock.cs");
	exec("./Weapon_AWP.cs");
	exec("./Weapon_870.cs");
}
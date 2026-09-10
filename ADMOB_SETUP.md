# Google AdMob Setup Guide

## Step 1: Create Google AdMob Account

1. Visit [Google AdMob](https://admob.google.com)
2. Sign in with your Google Account
3. Click **"Create an AdMob account"**
4. Accept AdMob policies

## Step 2: Create Android App

1. In AdMob dashboard, click **"Apps" > "Add App"**
2. Select **"Android"**
3. Fill in app details:
   - **App Name**: Kids Mobile Game
   - **Category**: Games > Casual
   - **Description**: A fun tap game for kids

## Step 3: Get Your Ad Unit IDs

After creating the app, you'll need to create ad units for each ad type:

### Banner Ad Unit
1. Click **"Ad Units" > "Create Ad Unit"**
2. Select **"Banner"**
3. Name: "Banner - Bottom"
4. Copy the **Ad Unit ID** (ca-app-pub-xxx/xxx)

### Interstitial Ad Unit
1. Click **"Ad Units" > "Create Ad Unit"**
2. Select **"Interstitial"**
3. Name: "Interstitial - Game Over"
4. Copy the **Ad Unit ID**

### Rewarded Ad Unit
1. Click **"Ad Units" > "Create Ad Unit"**
2. Select **"Rewarded"**
3. Name: "Rewarded - Bonus Points"
4. Copy the **Ad Unit ID**

## Step 4: Configure in Unity

Replace the placeholder Ad Unit IDs in `Assets/Scripts/GameManager.cs`:

```csharp
#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx"; // YOUR BANNER AD UNIT ID
#endif
```

Do this for:
- Banner Ad (`RequestBannerAd()`)
- Interstitial Ad (`RequestInterstitialAd()`)
- Rewarded Ad (`RequestRewardedAd()`)

## Step 5: Test Ads (Important!)

Before publishing, use **Test Device IDs** to avoid account suspension:

1. In AdMob dashboard, go **Settings > Test Devices**
2. Add your Android device ID
3. Find device ID:
   ```csharp
   // In GameManager.cs, add this to get device ID:
   Debug.Log("Device ID: " + SystemInfo.deviceUniqueIdentifier);
   ```
4. Run on device and check logcat for device ID
5. Add to AdMob Test Devices

## Step 6: Use Test Ad Unit IDs (Development)

During development, use Google's test ad unit IDs:

### Android Test Ad Unit IDs:

**Banner:**
```
ca-app-pub-3940256099942544/6300978111
```

**Interstitial:**
```
ca-app-pub-3940256099942544/1033173712
```

**Rewarded:**
```
ca-app-pub-3940256099942544/5224354917
```

Update `GameManager.cs` with these during testing:

```csharp
#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-3940256099942544/6300978111"; // Test Banner
#endif
```

## Step 7: Publish to Google Play Store

1. Once your app is approved by Google Play, update Ad Unit IDs to production IDs
2. Build release APK
3. Submit to Google Play Store

## Important Notes

⚠️ **DO NOT**:
- Click your own ads
- Use real ad unit IDs while testing
- Allow users to click ads repeatedly
- Use invalid traffic

✅ **DO**:
- Use test ad unit IDs during development
- Test on real Android devices
- Monitor earnings in AdMob dashboard
- Comply with Google policies

## Monitoring Earnings

1. Log into AdMob dashboard
2. View **Earnings** tab
3. Check CPM rates and impressions
4. Optimize ad placement based on performance

## Common Issues

**Issue: Ads not showing**
- Verify Ad Unit IDs are correct
- Check internet connection
- Use test ad units first
- Review AdMob policies compliance

**Issue: Account suspended**
- Review AdMob policies
- Check for invalid traffic
- Avoid clicking your own ads
- Contact AdMob support

---

**Questions?** Visit [AdMob Help Center](https://support.google.com/admob)

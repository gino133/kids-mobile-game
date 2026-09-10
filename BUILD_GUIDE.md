# Build & Deployment Guide

## Building the APK

### Prerequisites
- Unity 2020.3 LTS or newer
- Android Build Support installed
- JDK 8 or higher
- Android SDK (API 23+)

### Step 1: Configure Build Settings

1. Open **File > Build Settings**
2. Click **Android** and select **Switch Platform**
3. Click **Player Settings** (bottom-left)

### Step 2: Player Settings Configuration

**In Player Settings window:**

#### Company and Product Name
- Company Name: `Your Company Name`
- Product Name: `Kids Mobile Game`
- Package Name: `com.yourcompany.kidsgame`

#### Publishing Settings
- Minimum API Level: **Android 6.0 (API 23)**
- Target API Level: **Latest (API 33+)**
- Scripting Backend: **IL2CPP**

#### Resolution and Presentation
- Default Orientation: **Portrait**
- Allow Fullscreen: **Enabled**
- Status Bar Hidden: **Enabled** (for kids)

#### Other Settings
- Graphics APIs: **OpenGL ES 3.0**
- Enable MultiThreading: **Enabled**

### Step 3: Build Options

1. Return to Build Settings
2. Add Scenes to Build:
   - Click **Add Open Scenes** or drag scenes into the list
3. Select build type:
   - **Build APK** - For manual testing/sideloading
   - **Build and Run** - Builds and installs on connected device
   - **Build App Bundle** - For Google Play Store publishing

### Step 4: Generate Signed APK (For Publishing)

1. In Build Settings, click **Build**
2. Choose location and name (e.g., `KidsMobileGame.apk`)
3. For release, you'll need a keystore file:

#### Creating a Keystore (First time)

1. In Build Settings, select **Custom Keystore**
2. Click **Browse** and create new keystore:
   ```
   Keystore Name: android.keystore
   Keystore Password: [Your secure password]
   Key Alias: gamekey
   Key Password: [Your secure password]
   ```
3. Set validity to **25 years**
4. Save keystore in a safe location

**⚠️ IMPORTANT**: Save your keystore password! You'll need it for all future updates.

## Testing on Device

### Connect Android Device

1. Enable **Developer Mode**:
   - Go to Settings > About Phone
   - Tap "Build Number" 7 times

2. Enable **USB Debugging**:
   - Settings > Developer Options > USB Debugging
   - Connect via USB cable

3. In Build Settings, click **Build and Run**

### Monitor Performance

1. Open **Window > Analysis > Profiler**
2. Check FPS and memory usage
3. Optimize if needed

## Deployment to Google Play Store

### Step 1: Prepare for Submission

1. Version your build:
   - **Version Name**: 1.0.0
   - **Version Code**: 1 (increment for each update)

2. Create app bundle:
   - File > Build Settings
   - Select **Android App Bundle**
   - Build for release
   - Output: `KidsMobileGame.aab`

### Step 2: Set Up Google Play Store

1. Register at [Google Play Developer Console](https://play.google.com/console/)
2. Pay $25 developer fee
3. Create new app:
   - App name: Kids Mobile Game
   - Default language: English
   - App category: Games > Casual
   - Rating content: PG or PEGI 3

### Step 3: Create Store Listing

**Fill in all required fields:**

- **Title**: Kids Mobile Game (max 50 chars)
- **Short Description**: A fun tap game for everyone!
- **Full Description**: Detailed game description (4000 chars max)
- **Screenshots**: Upload 2-8 high-quality screenshots
- **Feature Graphic**: 1024x500px banner image
- **Icon**: 512x512px app icon
- **Video**: Optional YouTube trailer

### Step 4: Content Rating Questionnaire

1. Fill out Google Play content rating form
2. Select appropriate ratings (PEGI 3 for kids)
3. Ensure app complies with children's policies

### Step 5: Pricing and Distribution

- **Price**: Free (monetize via ads)
- **Countries**: Select where to distribute
- **Device categories**: Phones and tablets

### Step 6: Privacy Policy

**REQUIRED**: Create a privacy policy covering:
- AdMob ad serving
- Data collection
- Analytics (if used)

Example template:
```
This app displays ads via Google AdMob. 
We do not collect personal information from users.
Google AdMob may collect data per Google's privacy policy.
```

Host at: `yourwebsite.com/privacy`

### Step 7: Upload and Submit

1. Go to **Release > Production**
2. Upload app bundle (`.aab` file)
3. Review and submit
4. Wait for review (typically 1-2 hours)

## Post-Launch

### Monitor Analytics

1. Check **Statistics** for:
   - Install count
   - Uninstall rate
   - Rating and reviews

2. Monitor AdMob earnings in parallel

### Update Process

For updates:
1. Increment Version Code by 1
2. Build new app bundle
3. Upload to Google Play
4. Submit for review

## Troubleshooting

**Issue: "Android SDK not found"**
- Download Android SDK through Unity Hub
- Set path in Preferences > External Tools

**Issue: "Build failed"**
- Check logcat for errors: `adb logcat`
- Clear cache: `Assets > Reimport All`
- Update Google Mobile Ads SDK

**Issue: "App rejected by Play Store"**
- Review rejection reason
- Fix policy violations
- Resubmit

---

**You're ready to publish!** 🚀

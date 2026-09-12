# Kids Mobile Game - Android

A lightweight, fun, and kid-friendly mobile game for Android with Google AdMob integration to monetize through ads.

## Features

✅ **Simple Tap Game** - Easy-to-play mechanics perfect for children
✅ **Score System** - Track high scores and current score
✅ **Google AdMob Integration** - Earn money through:
   - Banner Ads (at the bottom)
   - Interstitial Ads (when game ends)
   - Rewarded Ads (optional bonus points)
✅ **Lightweight** - Minimal resources, runs smoothly on all Android devices
✅ **Kid-Friendly UI** - Colorful, intuitive interface
✅ **Social Sharing** - Share scores with friends

## Project Structure

```
Assets/
├── Scripts/
│   ├── GameManager.cs       # Core game logic & AdMob management
│   ├── TapGame.cs          # Tap game mechanics
│   └── UIManager.cs        # UI and game over screen
├── Scenes/
│   └── GameScene.unity
└── Resources/
    └── UI Elements (Prefabs, Sprites)
```

## Setup Instructions

### 1. Prerequisites
- **Unity 2020.3 LTS** or newer
- **Android Build Support** installed
- **Google Play Services** (for AdMob)

### 2. Install Google Mobile Ads SDK

1. Download [Google Mobile Ads SDK for Unity](https://developers.google.com/admob/unity/start)
2. Import into your project: `Assets > Import Package > Custom Package`
3. Choose `GoogleMobileAdsPlugin.unitypackage`

### 3. Configure AdMob

1. Go to [Google AdMob Console](https://admob.google.com)
2. Create an Android app and get your:
   - **App ID** (ca-app-pub-xxxxxxxxxxxxxxxx~xxxxxxxx)
   - **Ad Unit IDs** for:
     - Banner Ads
     - Interstitial Ads
     - Rewarded Ads

3. Replace the Ad Unit IDs in `GameManager.cs`:
   ```csharp
   string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxx";
   ```

### 4. Build for Android

1. **File > Build Settings**
2. Select **Android** platform
3. Configure Player Settings:
   - Company Name: Your Company
   - Product Name: Kids Mobile Game
   - Minimum API Level: Android 6.0 (API 23)
   - Target API Level: Latest

4. Click **Build APK** or **Build and Run**

## How to Play

1. **Tap the button** as many times as you can
2. **Earn points** with each tap (1 point per tap)
3. **Bonus multipliers** for consecutive taps
4. **Watch ads** to earn bonus points
5. **Share your score** with friends

## Monetization Strategy

### Revenue Streams:

1. **Banner Ads** - Passive income displayed during gameplay
2. **Interstitial Ads** - Show when game ends (highest CPM)
3. **Rewarded Ads** - Players voluntarily watch for bonus points

### Estimated Earnings:
- Average CPM (Cost Per Mille): $0.50 - $2.00 USD
- Depends on:
  - Country of users
  - Ad quality and relevance
  - User engagement

## Future Enhancements

- [ ] Multiple difficulty levels
- [ ] Sound effects and background music
- [ ] Achievements and badges
- [ ] Leaderboard system
- [ ] Power-ups and special items
- [ ] Daily rewards
- [ ] Offline mode
- [ ] Firebase Analytics integration
- [ ] App Store optimization (ASO)

## Publishing to Google Play Store

### Requirements:
1. Google Play Developer Account ($25 one-time fee)
2. Generate signed APK
3. Create app listing with screenshots and description
4. Set appropriate rating (PEGI 3 or ESRB E for kids)
5. Submit for review (1-2 hours typically)

### Best Practices:
- Add privacy policy (Google Play Store requirement)
- Keep ads appropriate for kids
- Test thoroughly on various Android devices
- Gather user feedback and iterate

## Files to Customize

- `GameManager.cs` - Add your AdMob Ad Unit IDs
- `Assets/Scenes/GameScene.unity` - Design your UI
- Game sprites and sound effects

## Support

For AdMob issues: [Google AdMob Help](https://support.google.com/admob)
For Unity issues: [Unity Forums](https://forum.unity.com/)

## License

MIT License - Feel free to use and modify

---

**Happy Game Development! 🎮**

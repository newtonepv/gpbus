# GPBus for passengers

## Description
This is an app made with the objective of: 
- Tracking public buses in real time.
- Reading, making and rating comments about public buses.

<hr>

## Features
### Login page
- User authentication (do not use a password you frequently use on other websites).
### Register page
- User creation.
### Home page
- View an interactive map for visualizing bus routes and locations.
- Select a specific bus to see its designated route and track its real-time position.
- See your current location displayed on the map.
- Bus comments visualization, rating and submission.
- Simulate bus movement for demonstration purposes. A dedicated button allows you to move bus #200 along its route, which is useful for testing the tracking feature without the driver application. That button is in this part of the page:
<p align="center" style="margin: 0; padding: 0;">
  <img src="../readme_images/moove_bus_200.jpeg" alt="moove bus 200 button ilustration" width="400">
</p>

### Alarm Features
- Create custom alarms to receive a notification when a specific bus enters a user-defined area on the map.

<hr>

## Pending features
- Language selection (only portuguese for now).
- User password recovery by email.
- Gamification.
- Dark mode.
- Favorite buses.

<hr>

## Installing & running
### Prerequisites
(Do not require android studio).
- Flutter & Dart (SDK) version higher than 3.0.0.
- Chrome browser.
### Installling steps
- Clone the repository:
  ```bash
  git clone https://github.com/newtonepv/gpbus_mobile.git
  cd gpbus_mobile
  ```
- Install dependencies:
  ```bash
  cd gpbus_passanger
  flutter pub get
  ```
### Running steps
#### Running the app on chrome:
 ```bash
 flutter run -d chrome
 ```
#### Enablnig the app to run on a Android device:
- Enable developer mode.
- Enable USB Debugging.
- Connect via USB.

#### Enablnig the app to run on a IOS device:
- Connect via USB or wireless.
- Trust developer certificate.

#### Running the app on mobile device:
```bash
  flutter run
  ```

import 'package:geolocator/geolocator.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_location_exceptions.dart';

Future<Position> getCurrentLocation() async {
  bool serviceEnabled = await Geolocator.isLocationServiceEnabled();
  //Tratamento de erros de não ativação de localização:
  if (!serviceEnabled) {
    throw CustomLocationServiceDisabledException('Habilite a localização.');
  }

  LocationPermission permission = await Geolocator.checkPermission();

  //Tratamento de erros de permissão:
  List<LocationPermission> deniedPermissions = [LocationPermission.deniedForever, LocationPermission.denied];
  if (deniedPermissions.contains(permission)) {
    permission = await Geolocator.requestPermission();
    if (deniedPermissions.contains(permission)) {
      throw CustomLocationPermissionDeniedException('As permissões de localização foram negadas, vá para configurações e habilite.');
    }
  }

  return await Geolocator.getCurrentPosition(
    desiredAccuracy: LocationAccuracy.high,
  );
}
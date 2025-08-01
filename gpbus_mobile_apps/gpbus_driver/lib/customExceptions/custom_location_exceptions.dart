class CustomLocationPermissionDeniedException implements Exception {
  final String message;
  CustomLocationPermissionDeniedException(this.message);
  
  @override
  String toString() => message;
}
class CustomLocationServiceDisabledException implements Exception {
  final String message;
  CustomLocationServiceDisabledException(this.message);
  
  @override
  String toString() => message;
}
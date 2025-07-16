bool filters(String userName, String password) {
  // Não permite campos em branco
  if (userName.trim().isEmpty || password.trim().isEmpty) {
    return false;
  }
  // Não permite caracteres especiais (apenas letras, números e underline)
  final regex = RegExp(r'^[a-zA-Z0-9_]+$');
  if (!regex.hasMatch(userName) || !regex.hasMatch(password)) {
    return false;
  }
  return true;
}
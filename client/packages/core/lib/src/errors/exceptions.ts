class AppException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "AppException";
    Object.setPrototypeOf(this, new.target.prototype);
  }
}

class AuthenticationException extends AppException {
  constructor(message: string) {
    super(message);
  }
}

class DatabaseException extends AppException {
  constructor(message: string) {
    super(message);
  }
}

class PermissionException extends DatabaseException {
  constructor(message: string) {
    super(message);
  }
}

class NotFoundException extends DatabaseException {
  constructor(message: string) {
    super(message);
  }
}

class NetworkException extends AppException {
  constructor() {
    super("Please check your internet connection");
  }
}

class UnknownException extends AppException {
  constructor() {
    super("An unknown error occurred.");
  }
}

export {
  AppException,
  AuthenticationException,
  DatabaseException,
  PermissionException,
  NotFoundException,
  NetworkException,
  UnknownException
};

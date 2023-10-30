export class User {
    // Properties
    Name: string;
    Email?: string;
    PhoneNumber: string;
  
    // Constructor
    constructor(name: string, Email: string, PhoneNumber: string) {
      this.Name = name;
      this.Email = Email;
      this.PhoneNumber = PhoneNumber;
    }
  }
export interface User {
  Id: number
  IBAN: string
  ReferenceNumber: string
  FirstName: string
  LastName: string
  DisplayName: string
  Mail?: string
  Password?: string
  Token?: string
}

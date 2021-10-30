import { User } from "@/models/User";
import UserStore from "./UserStore";

class CryptoProvider {
  async generateUser(username: string): Promise<User | undefined> {
    const user = {
      name: username,
      publicKey: this.randomBase64(),
      privateKey: "hiImTheMeUser",
    };

    return user;
  }

  randomBase64(length = 32): string {
    // Declare all characters
    const chars =
      "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    // Pick characers randomly
    let str = "";
    for (let i = 0; i < length; i++) {
      str += chars.charAt(Math.floor(Math.random() * chars.length));
    }

    return btoa(str);
  }
}

export default new CryptoProvider();

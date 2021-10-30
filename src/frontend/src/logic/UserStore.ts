import localforage from "localforage";
import { User } from "../models/User";

class UserStore {
  public async me(): Promise<User | undefined> {
    var matches = ((await localforage.getItem("users")) as User[]).filter(
      (u) => u.privateKey
    );

    if (matches.length === 0) {
      return undefined;
    }

    return matches[0];
  }

  public async add(user: User): Promise<void> {
    let users =
      ((await localforage.getItem("users")) as User[]) ?? ([] as User[]);

    users.push(user);

    await localforage.setItem("users", users);
  }

  public async remove(user: User): Promise<void> {
    let users =
      ((await localforage.getItem("users")) as User[]) ?? ([] as User[]);

    users = users.filter((u) => u.publicKey !== user.publicKey);

    await localforage.setItem("users", users);
  }
}

export default new UserStore();

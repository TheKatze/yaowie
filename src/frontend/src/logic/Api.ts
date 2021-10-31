import { Transaction } from "@/models/Transaction";
import { User } from "@/models/User";
import { Axios } from "axios";

class Api {
  axios: Axios | undefined;

  initialize(axios: Axios): void {
    this.axios = axios;
  }

  async fetchQueue(publicKey: string): Promise<Transaction[]> {
    const response = await this.axios?.get("/eventqueue/" + publicKey);

    return JSON.parse(response?.data) as Transaction[];
  }

  async createTransaction(transaction: Transaction): Promise<void> {
    await this.axios?.post("/transaction", transaction);
  }

  async createUser(user: User) {
    console.log(user);

    await this.axios?.post(
      "/user",
      JSON.stringify({
        name: user.name,
        publicKey: user.publicKey,
      })
    );
  }

  async getUser(publicKey: string): Promise<User | undefined> {
    const response = await this.axios?.get("/user/" + publicKey);

    if (response?.status != 200) return undefined;

    return JSON.parse(response?.data) as User;
  }
}

export default new Api();

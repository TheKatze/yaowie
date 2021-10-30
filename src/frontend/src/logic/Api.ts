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

    return response?.data as Transaction[];
  }

  async createTransaction(transaction: Transaction): Promise<void> {
    await this.axios?.post("/transaction", transaction);
  }

  async createUser(user: User) {
    await this.axios?.post("/user", user);
  }
}

export default new Api();

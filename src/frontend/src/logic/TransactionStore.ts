import localforage from "localforage";
import { Transaction } from "../models/Transaction";

class TransactionStore {
  public async add(transaction: Transaction): Promise<void> {
    let transactions =
      ((await localforage.getItem("transactions")) as Transaction[]) ??
      ([] as Transaction[]);

    transactions.push(transaction);

    await localforage.setItem("transactions", transactions);
  }
}

export default new TransactionStore();

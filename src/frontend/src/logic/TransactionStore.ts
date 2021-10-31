import localforage from "localforage";
import { Transaction } from "../models/Transaction";

class TransactionStore {
  public async add(transaction: Transaction): Promise<void> {
    const transactions =
      ((await localforage.getItem("transactions")) as Transaction[]) ??
      ([] as Transaction[]);

    transactions.push(transaction);

    await localforage.setItem("transactions", transactions);
  }

  public async list(): Promise<Transaction[]> {
    return (
      ((await localforage.getItem("transactions")) as Transaction[]) ??
      ([] as Transaction[])
    );
  }
}

export default new TransactionStore();

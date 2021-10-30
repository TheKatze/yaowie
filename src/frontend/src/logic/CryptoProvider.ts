import localforage from "localforage";
import UserStore from "./UserStore";

class CryptoProvider {
  async generateKeyPair(username: string): Promise<void> {
    if (await UserStore.me()) return;

    var keys = await window.crypto.subtle.generateKey(
      {
        name: "RSA-OAEP",
        modulusLength: 4096,
        publicExponent: new Uint8Array([1, 0, 1]),
        hash: "SHA-256",
      },
      true,
      ["encrypt", "decrypt"]
    );

    await UserStore.add({
      name: username,
      publicKey: await this.keyToBase64(keys.publicKey!),
      privateKey: await this.keyToBase64(keys.privateKey!),
    });
  }
  async keyToBase64(key: CryptoKey): Promise<string> {
    var buffer = await window.crypto.subtle.exportKey("raw", key);
    var binary = "";
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
      binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
  }
}

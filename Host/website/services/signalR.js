
import * as signalR from "@microsoft/signalr";

let connection = null;

export function startConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5004/chathub", {
            accessTokenFactory: () => localStorage.getItem("access_token"), // اگه JWT داری
        })
        .withAutomaticReconnect()
        .build();

    return connection
        .start()
        .then(() => {
            console.log("SignalR Connected");
        })
        .catch((err) => console.error("Connection failed: ", err));
}

export function onReceiveMessage(callback) {
    if (connection) {
        connection.on("ReceiveMessage", (message) => {
            callback(message);
        });
    }
}

export function sendMessage(receiverId, message) {
    if (connection) {
        return connection
            .invoke("SendMessage", receiverId, message)
            .catch((err) => console.error(err));
    }
}

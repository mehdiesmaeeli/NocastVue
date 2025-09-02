<template>
    <div>
        <div v-for="msg in messages" :key="msg.id">
            <b>{{ msg.senderId }}</b>: {{ msg.content }}
        </div>

        <input v-model="newMessage" @keyup.enter="send" placeholder="Type a message..." />
    </div>
</template>

<script>
import { startConnection, onReceiveMessage, sendMessage } from "@/services/signalr";

    export default {
        data() {
            return {
                messages: [],
                newMessage: "",
                receiverId: "GUID-OF-USER", // مثلا از route یا props
                connectionStarted: false,
            };
        },
        async mounted() {
            const token = localStorage.getItem("access_token"); // JWT واقعی
            if (!token) {
                console.warn("No token found. Redirect to login.");
                return;
            }

            try {
                await startConnection(); // توکن رو به startConnection پاس بده
                this.connectionStarted = true;

                onReceiveMessage((msg) => {
                    this.messages.push(msg);
                });
            } catch (err) {
                console.error("SignalR connection failed:", err);
            }
        },
        methods: {
            send() {
                if (!this.connectionStarted) return; // اطمینان از اتصال
                if (this.newMessage.trim()) {
                    sendMessage(this.receiverId, this.newMessage);
                    this.newMessage = "";
                }
            },
        },
    };
</script>

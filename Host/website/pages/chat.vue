<template>
    <div class="chat-page">
        <!--<ChatHeader :avatar="user.avatar"
                    :name="user.name"
                    :status="user.status" />
        <ChatMessages :messages="messages" />
        <ChatInput @send="handleSend" />-->
        <chat></chat>
    </div>
</template>

<script>
    import ChatHeader from '@/components/ChatHeader.vue';
    import ChatMessages from '@/components/ChatMessages.vue';
    import ChatInput from '@/components/ChatInput.vue';

    export default {
        components: {
            ChatHeader,
            ChatMessages,
            ChatInput,
        },
        data() {
            return {
                user: {
                    avatar: 'https://i.pravatar.cc/40?img=1',
                    name: 'Ali',
                    status: 'Online',
                },
                messages: [
                    { from: 'me', text: 'سلام!' },
                    { from: 'other', text: 'سلام علی! خوبی؟' },
                ],
            };
        },
        methods: {
            handleSend(message) {
                this.messages.push({ from: 'me', text: message });
                // ارسال پیام به سرور یا انجام عملیات مورد نظر
            },
        },
    };
</script>

<style scoped>
    .chat-page {
        display: flex;
        flex-direction: column;
        height: 100vh;
    }
</style>

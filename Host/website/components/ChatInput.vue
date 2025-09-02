<template>
    <div class="env-pb bg-white fixed w-100 bottom-0">
        <div class="bk_footer_input emBK__buttonsShare snipcss0-0-0-1 tether-element-attached-top tether-element-attached-center tether-target-attached-top tether-target-attached-center">
            <button type="button" class="btn btn_upload p-0 snipcss0-1-1-2" data-toggle="modal" data-target="#mdllButtons">
                <div class="icon bg-snow rounded-10 snipcss0-2-2-3 XXsnipcss_extracted_selector_selectionXX snipcss0-0-0-1 tether-element-attached-top tether-element-attached-center tether-target-attached-top tether-target-attached-center">
                    <i class="ri-attachment-line size-20 snipcss0-3-3-4 snipcss0-1-1-2"></i>
                </div>
            </button>
            <div class="form-group m-0 snipcss0-1-1-5">
                <input type="text" class="form-control snipcss0-2-5-6" placeholder="Type a message here">
            </div>
            <button type="button" class="btn btn_defSend rounded-10 snipcss0-1-1-7">
                <svg id="Iconly_Bulk_Send" data-name="Iconly/Bulk/Send" xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" class="snipcss0-2-7-8">
                    <g id="Send" transform="translate(1.667 1.667)" class="snipcss0-3-8-9">
                        <path id="Fill_1" data-name="Fill 1" d="M16.19.482A1.615,1.615,0,0,0,14.581.065L1.173,3.939A1.6,1.6,0,0,0,.02,5.2,1.863,1.863,0,0,0,.855,6.94L5.048,9.5a1.09,1.09,0,0,0,1.341-.159l4.8-4.8a.613.613,0,0,1,.883,0,.629.629,0,0,1,0,.883l-4.809,4.8A1.092,1.092,0,0,0,7.1,11.565l2.562,4.208a1.668,1.668,0,0,0,1.592.774,1.62,1.62,0,0,0,1.358-1.15L16.59,2.09a1.619,1.619,0,0,0-.4-1.608" transform="translate(0 0)" fill="#fff"></path>
                        <path id="Combined_Shape" data-name="Combined Shape" d="M3.97,6.355a.625.625,0,0,1,0-.883L5.108,4.333a.625.625,0,1,1,.884.884L4.854,6.355a.625.625,0,0,1-.883,0ZM3.317,3.2a.625.625,0,0,1,0-.884L4.455,1.176a.625.625,0,0,1,.884.884L4.2,3.2a.625.625,0,0,1-.883,0ZM.183,2.2a.625.625,0,0,1,0-.884L1.321.182a.625.625,0,0,1,.884.884L1.066,2.2a.625.625,0,0,1-.884,0Z" transform="translate(0.217 9.952)" fill="#fff" opacity="0.4"></path>
                    </g>
                </svg>

            </button>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      newMessage: '',
    };
  },
  methods: {
    sendMessage() {
      if (this.newMessage.trim()) {
        this.$emit('send', this.newMessage);
        this.newMessage = '';
      }
    },
  },
};
</script>

<style scoped>
    .chat-input {
        display: flex;
        padding: 10px;
        border-top: 1px solid #ddd;
    }

        .chat-input input {
            flex-grow: 1;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 20px;
            margin-right: 10px;
        }

        .chat-input button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 8px 12px;
            border-radius: 20px;
            cursor: pointer;
        }
</style>

<template>
  <div class="custom-modal">
    <div class="popup">
      <div class="modal-header">
        <slot name="header"></slot>
        <i class="fa fa-close close-modal" @click="closeModal()"></i>
      </div>
      <div class="modal-body">
        <slot name="body"></slot>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  props: {
    name: {
      type: String,
      default: "defaultModal"
    },
  },
  methods: {
    closeModal() {
      this.emitter.emit(this.name, false);
    },
  }
}
</script>


<style scoped>
  .modal-header {
    color: #fff;
  }
  .custom-modal {
    display: flex;
    align-items: flex-start;
    justify-content: center;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    position: absolute;
    z-index: 5;
  }
  .popup {
    background: rgba(3,3,3, .8);
    width: 750px;
    min-height: 450px;
    margin: 0 auto;
  }
  .close-modal {
    color: #fff;
    font-size: 36px;
    margin: 0 10px 0 auto;
    cursor: pointer;
  }
  .modal-header {
    display: flex;
    flex-wrap: wrap;
  }
  .close-modal:hover {
    color: rgb(207, 194, 194);
  }
</style>
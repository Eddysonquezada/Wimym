<template>
<div id="uploader">
    <el-button type="primary" @click="openDialogFiles">
        <i class="fa fa-plus"></i>
    </el-button>
    <input class="input-file hidden" type="file" accept="image/*" />
</div>
</template>

<script>
export default {
  name: "AddToGallery",
  props: {},
  data: () => ({

  }),
  methods: {
      openDialogFiles() {
          document.querySelector('#uploader .input-file').click();
      }
  },
  created() {}
};
</script>

<style>
#uploader {
    position: fixed;
    right: 20px;
    bottom: 20px;
    z-index:2;
}

#uploader .el-button{
    border-radius: 100%;
    padding: 15px;
    font-size: 1.4em;
}
</style>

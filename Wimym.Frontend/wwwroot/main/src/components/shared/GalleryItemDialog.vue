<template>
<div>
    <el-dialog
    title="Tips"
    :visible.sync="dialogVisible"
    width="30%"
    :before-close="handleClose">
    <span>This is a message</span>
    <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">Cancel</el-button>
        <el-button type="primary" @click="dialogVisible = false">Confirm</el-button>
    </span>
    </el-dialog>
</div>
</template>

<script>
export default {
  name: "Default",
  props: {
    rows: {
      type: String,
      default: "5"
    }
  },
  data: () => {},
  methods: {},
  created() {}
};
</script>

<style>
</style>
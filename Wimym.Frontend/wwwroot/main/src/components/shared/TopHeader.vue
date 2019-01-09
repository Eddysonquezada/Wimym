<template>
  <el-row>
    <el-col :span="10">
      <h1 @click="goTo('/')"><i class="fa fa-camera"></i> AnexGram</h1>
    </el-col>
    <el-col :span="4" class="text-center">
      <el-input placeholder="Buscar .." suffix-icon="fa fa-search"></el-input>
    </el-col>
    <el-col :span="10" class="text-right user-options">
      <a class="item" href="#">
        <i class="fa fa-user"></i>
      </a>
      <a class="item" href="#">
        <i class="fa fa-sign-out-alt"></i>
      </a>
    </el-col>
  </el-row>
</template>

<style>
#header {
  height: 60px;
  line-height: 60px;
  background: #fff;
  border-bottom: 1px solid #ccc;
  box-shadow: 0px 0px 15px 0px #eee;
}

#header h1 {
  margin: 0;
}

#header .user-options a{
  color: #222;
}

#header .user-options .item {
  font-size: 1.5em;
  padding:5px 15px;
  border-radius:10px;
  margin-right: 5px;
}

#header .user-options .item:hover {
  background:#fff;
}

#header .el-header .user-options .item:last-child {
  margin-right: 0;
}
</style>

<script>
export default {
  name: "TopHeader",
  data: () => ({

  }),
  methods: {
    goTo(path) {
      debugger
      if(path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>
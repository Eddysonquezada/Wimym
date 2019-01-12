<template>
<div id="gallery-container" v-masonry transition-duration="0.3s" item-selector=".item">
    <div v-masonry-tile v-for="item in items" :class="'item item-' + rows">
        <el-card :body-style="{ padding: '0px' }">
            <div slot="header" class="clearfix">
                <el-row>
                    <el-col :span="20">
                        <img class="avatar" :src="item.user.photo" >
                        @{{item.user.nickname}}
                    </el-col>
                    <el-col :span="4" class="text-right">
                        <i class="far fa-heart"></i>
                    </el-col>
                </el-row>
            </div>
            <div class="img-container">
                <div class="expand">
                    <i class="fa fa-expand"></i>
                </div>
                <img :src="item.image" />
            </div>
            <div class="content">
                {{item.description}}
                <el-row class="info">
                  <el-col :span="20" class="time">
                    <i class="fa fa-calendar"></i> {{item.publishedAt}}
                  </el-col>
                  <el-col :span="4" class="comment">
                    <i class="far fa-comment"></i> 20
                  </el-col>
                </el-row>
            </div>
        </el-card>
    </div>
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
  data: () => ({
    items: [
      {
        image: "./static/image/cuadros.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Retrato de mi película favorita ..",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-1.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-3.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-1.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-2.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-3.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/pelicula.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/walt.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "PerritooOoOOo ...",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-1.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-2.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },      {
        image: "./static/image/cuadros.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Retrato de mi película favorita ..",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-1.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-3.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      },      {
        image: "./static/image/cuadros.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Retrato de mi película favorita ..",
        publishedAt: "hace una hora"
      },
      {
        image: "./static/image/paisaje-1.jpg",
        user: {
          name: "Eduardo",
          fullName: "Eduardo Rodríguez",
          nickname: "erodriguez",
          photo: "./static/image/eduardo.jpg"
        },
        description: "Increíble lugar, me gustaría visitarlo otra vez",
        publishedAt: "hace una hora"
      }
    ]
  }),
  methods: {},
  created() {}
};
</script>

<style>
#gallery-container .item-6 {
  width: calc(100% / 6);
}

#gallery-container .item-5 {
  width: calc(100% / 5);
}

#gallery-container .item-4 {
  width: calc(100% / 4);
}

#gallery-container .item-3 {
  width: calc(100% / 3);
}

#gallery-container .item-2 {
  width: calc(100% / 2);
}

#gallery-container .item-1 {
  width: 100%;
}

#gallery-container .el-card {
  margin: 20px;
}

#gallery-container .item .img-container {
  position: relative;
  overflow: hidden;
}

#gallery-container .item .el-card__header {
  cursor: pointer;
  height: 60px;
  line-height: 60px;
  padding: 0;
  padding: 0 14px;
}

#gallery-container .item .img-container .expand {
  position: absolute;
  top: -5px;
  left: 0;
  height: 100%;
  width: 100%;
  background: #222;
  color: #fff;
  z-index: 1;
  opacity: 0.5;
  font-size: 6em;
  justify-content: center;
  align-items: center;
  display: none;
  cursor: pointer;
}

#gallery-container .item .img-container:hover .expand {
  display: flex;
}

#gallery-container .item .img-container img {
  width: 100%;
  margin: 0;
  padding: 0;
  min-height: 100%;
}

#gallery-container .item .avatar {
  float: left;
  border-radius: 100%;
  margin-right: 10px;
  height: 36px;
  margin-top: 10px;
  border: 2px solid #409eff;
  padding: 2px;
}

#gallery-container .item .content {
  padding: 15px;
  font-size: .9em;
}

#gallery-container .item .info {
  color: #888;
  display: block;
  font-size: 0.8em;
  margin-top: 10px;
  text-transform: uppercase;
}

#gallery-container .item .comment {
  text-align: right;
}

#gallery-container .item .time .fa {
  margin-right: 4px;
}
</style>
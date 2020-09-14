<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Домашняя страница</router-link> |
      <router-link to="/films">Мои фильмы</router-link> |
      <router-link to="/add">Добавить отснятый фильм</router-link>|
      <router-link :to="{name: 'VFilm', props: {id: 6}}"> Посмотреть фильм</router-link>
    </div>
    <router-view/>
  </div>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
  a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
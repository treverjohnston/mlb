<template>
  <q-page class="flex flex-center">
    <img alt="Quasar logo" src="~assets/quasar-logo-full.svg" @click="getTodayGames">
    <div class="row">
      <div v-for="game in games" class="col-xs-12">
        <div class="row">
          <div class="col-xs-2">Home ID</div>
          <div class="col-xs-2"></div>
          <div class="col-xs-2">Away ID</div>
          <div class="col-xs-2">Winner ID</div>
        </div>
        <div class="row">
          <div class="col-xs-2">{{game.homeTeamId}}</div>
          <div class="col-xs-2"></div>
          <div class="col-xs-2">{{game.awayTeamId}}</div>
          <div class="col-xs-2" v-if="game.winnerId > 0">{{game.winnerId}}</div>
          <div class="col-xs-2" v-else></div>
        </div>
      </div>
    </div>
  </q-page>
</template>

<script>
  export default {
    name: 'Home',
    data() {
      return {
      }
    },
    computed: {
      games() {
        return this.$store.state.games.todayGames;
      },
    },
    methods: {
      getTodayGames(){
        this.$store.dispatch(`games/getTodayGames`);
      }
    },
    mounted() {
      this.$store.dispatch(`games/getTodayGames`);
    }
  }
</script>
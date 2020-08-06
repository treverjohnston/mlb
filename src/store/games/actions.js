import axios from 'axios'

var production = !window.location.host.includes('localhost');
var baseUrl = production ? '' : '//localhost:5001/api/games';

let api = axios.create({
    baseURL: baseUrl,
    timeout: 4000,
    withCredentials: true
})

export function getTodayGames({ commit, dispatch }, id) {
    api.get('/today')
        .then(res => {
            console.log('res', res)
            commit('setTodayGames', res.data);
        })
        .catch(err => {
            console.error('Error getting all games', err)
        })
}
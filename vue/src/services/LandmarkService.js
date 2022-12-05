import axios from 'axios';

export default {

    getLandmarks() {
        return axios.get('/landmark');
    }

  
  }
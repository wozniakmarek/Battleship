import AxiosServices from '../services/AxiosServices'
import Configurations from '../configurations/Configuration'

const axiosServices = new AxiosServices()

export default class AuthServices {
  SignUp(data) {
    return axiosServices.post(Configurations.SignUp, data, false)
  }

  SignIn(data) {
    return axiosServices.post(Configurations.SignIn, data, false)
  }
  
  createDummyUser() {
    return axiosServices.post(Configurations.CreateDummyUser, {}, false);
  }
}


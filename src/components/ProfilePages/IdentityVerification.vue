<template>
  <div class="personal-info-block main-page-block">
    <b-form v-on:submit="submitIdentity($event)">
      <div class="col-sm-6">
        <div class="form-group left">
          <label>Full Name</label>
          <div class="single-line-group">
            <input
              placeholder="First Name"
              name="FirstName"
              v-model="user.firstName"
              required
              class="form-control cell-6"
              type="text"
            />
            <input
              placeholder="Last Name"
              name="LastName"
              v-model="user.lastName"
              required
              class="form-control cell-6"
              type="text"
            />
          </div>
        </div>
        <div class="form-group left">
          <label>Birth Date</label>
          <div class="single-line-group">
            <input
              placeholder="year"
              required
              name="Year"
              class="form-control cell-4"
              min="1900"
              :max="(new Date).getFullYear() - 18"
              type="number"
            />
            <input
              placeholder="month"
              required
              name="Month"
              class="form-control cell-4"
              min="1"
              max="12"
              type="number"
            />
            <input
              placeholder="day"
              required
              name="Day"
              class="form-control cell-4"
              min="1"
              max="31"
              type="number"
            />
          </div>
        </div>
        <div class="form-group left">
          <label>Phone Number</label>
          <div class="single-line-group">
            <select name="DialCode" required class="cell-4 form-control">
              <option value selected disabled>Dial code</option>
              <option
                v-for="(item, index) in countries"
                :key="index"
                :value="item.dial_code"
              >{{ item.code + ' (' + item.dial_code + ')' }}</option>
            </select>
            <input
              placeholder="Number"
              name="Phone"
              required
              class="cell-8 form-control"
              type="text"
            />
          </div>
        </div>
        <div class="form-group left">
          <label>Passport Info</label>
          <div class="single-line-group">
            <input
              placeholder="Passport Code"
              name="PassportCode"
              required
              class="cell-6 form-control"
              type="text"
            />
            <b-btn
              type="button"
              title="Upload photos of your passport"
              class="cell-6 btn-primary btn-bordered"
            >
              Upload
              <input
                title="Upload photos of your passport"
                class="file-control"
                required
                ref="photo"
                type="file"
                v-on:change="handleUpload(0)"
                multiple
                accept="image/*"
              />
              <span :style="{width: progressWidth}" class="upload-progress">{{ progressWidth }}</span>
            </b-btn>
          </div>
          <div class="photos-block">
            <div
              class="photo-item"
              :style="{'background-image': 'url(' + item + ')'}"
              :key="index"
              v-for="(item, index) in uploadedPhotos"
            >
              <div class="remove-background">
                <span @click="deletePhoto(index)" class="remove-icon">&times;</span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-sm-6">
        <div class="form-group left">
          <label>Residence</label>
          <div class="single-line-group">
            <select name="Country" required class="form-control cell-6">
              <option value disabled selected>Country</option>
              <option :value="item.name" :key="index" v-for="(item, index) in countries">{{ item.name }}</option>
            </select>

            <input
              required
              class="form-control cell-6"
              name="ZipCode"
              placeholder="ZIP-Code"
              type="text"
            />
          </div>
        </div>
        <div class="form-group left">
          <label>Region / Province</label>
          <input required class="form-control" name="Region" placeholder="Region" type="text" />
        </div>
        <div class="form-group left">
          <label>City</label>
          <input required class="form-control" name="City" placeholder="City" type="text" />
        </div>
        <div class="form-group left">
          <label>Home Address</label>
          <input required class="form-control" name="Address" placeholder="Street" type="text" />
        </div>
      </div>

      <div class="form-group centered">
        <b-btn type="submit" class="btn-primary">Confirm Identity</b-btn>
      </div>
    </b-form>
  </div>
</template>
<script>
import { mapGetters } from "vuex";
import axios from "axios";
import countries from "../../data/countries.json";
export default {
  data() {
    return {
      countries: countries,
      uploadedPhotos: [],
      progressWidth: ""
    };
  },
  computed: mapGetters({
    user: "getUser"
  }),
  methods: {
    submitIdentity(event) {
      event.preventDefault();
      let formData = new FormData(event.target);
      let data = {};
      formData.forEach(function(v, k) {
        data[k] = v;
      });
      data["PhoneNumber"] = '(' + data["DialCode"] + ')-' + data["Phone"];
      data["BirthDate"] =
        data["Year"] + "/" + data["Month"] + "/" + data["Day"];
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/account/identity",
        data: data,
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token")
        }
      })
        .then(response => {
          
        })
        .catch(error => {
          console.log(error);
        });
    },
    handleUpload(index) {
      if (index === -1 || this.$refs.photo.files == null) return true;
      let filesLength = this.$refs.photo.files.length;
      console.log(this.$refs.photo.files[index]);
      let data = new FormData();
      data.append("file", this.$refs.photo.files[index]);
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/account/uploadfile",
        data: data,
        proccessData: false,
        contentType: false,
        onUploadProgress: progressEvent => this.processUploading(progressEvent),
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token")
        }
      })
        .then(response => {
          if (response) {
            that.progressWidth = "";
            that.uploadedPhotos.push(response.data.fileName);
            that.handleUpload(filesLength > ++index ? index : -1);
          }
        })
        .catch(error => {
          console.log(error);
          that.progressWidth = "";
        });
    },
    deletePhoto(index) {
      this.uploadedPhotos.splice(index, 1);
      if (this.uploadedPhotos.length === 0) this.$refs.photo.value = "";
    },
    processUploading(progressEvent) {
      this.progressWidth =
        Math.round((progressEvent.loaded * 100) / progressEvent.total) + "%";
    }
  }
};
</script>
<style scoped>
.photos-block {
  display: flex;
  overflow-x: auto;
}

.file-control {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  opacity: 0;
}

.photo-item {
  border-radius: 5px;
  width: 33%;
  height: 100px;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center center;
  position: relative;
  margin: 8px 5px;
}

.remove-background {
  opacity: 0;
  height: 100%;
  width: 100%;
  border-radius: 5px;
  z-index: 1;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-align: center;
  -ms-flex-align: center;
  align-items: center;
  -webkit-transition: 0.5s opacity;
  transition: 0.5s opacity;
  background: rgba(14, 14, 14, 0.87);
}

.remove-background:hover {
  opacity: 1;
}

.upload-progress {
  width: 0;
  background-color: #3d2798;
  height: 100%;
  position: absolute;
  z-index: 2;
  left: 0;
  color: #fff;
  top: 0;
}

.remove-icon {
  font-size: 30px;
  color: #ffffff;
  z-index: 2;
  height: 45px;
  margin: auto;
  width: 45px;
  cursor: pointer;
  border: 1px solid;
  text-align: center;
  border-radius: 50%;
}
</style>

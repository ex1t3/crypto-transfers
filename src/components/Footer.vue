<template>
  <footer class="islb-crypto-transfers--footer">
    <b-container>
      <b-row>
        <div class="col-sm-8 left">
          <a class="footer-brand">ISLB</a>
          <p>ISLB &copy; All rights reserved.</p> 
          <p>Estonian digital exchange license</p>
          <div>
            <img style="width: 15%" src="./img/european-union.jpg"/>
            <img style="margin-left: 5px; width: 25%" src="./img/ministry-logo.png"/>
          </div>
          <p> <u>FRK000092</u>,  <u>FVR000112</u> </p>
        </div>
        <div class="col-sm-4 left">
          <p>Follow us on:</p>
          <p>
            <a class="footer-social-link" href="#">
              <img src="./img/facebook-white.svg" />
            </a>
            <a class="footer-social-link" href="#">
              <img src="./img/twitter-white.svg" />
            </a>
            <a class="footer-social-link" href="#">
              <img src="./img/instagram-white.svg" />
            </a>
            <a class="footer-social-link" href="#">
              <img src="./img/youtube-white.svg" />
            </a>
          </p>
        </div>
      </b-row>
      <b-row>
        <div class="col-sm-12 left">
          <p>
            <a class="footer-link" href="#">Terms & Conditions</a>
            <a class="footer-link" href="#">Privacy policy</a>
            <a class="footer-link" href="#">Fees</a>
            <a class="footer-link" href="#">Supported countries</a>
            <a class="footer-link" href="#">About</a>
          </p>
        </div>
      </b-row>
      <b-row></b-row>
    </b-container>
  </footer>
</template>
<style scoped>
.islb-crypto-transfers--footer {
  background: linear-gradient(225deg, #3d2ebf, #6559cc);
  min-height: 200px;
  margin-top: 50px;
  color: #fff;
  padding-top: 35px;
  width: 100%;
  bottom: 0;
}
.footer-brand {
  display: inline-block;
  cursor: pointer;
  margin-right: 1rem;
  margin-bottom: 10px;
  font-size: 2.1rem;
  line-height: inherit;
  white-space: nowrap;
  letter-spacing: 10px;
  border: 1px solid;
  padding: 8px 12px;
  font-weight: 300;
  padding-left: 22px;
}
.footer-social-link {
  margin-right: 15px;
  padding: 5px;
  border-radius: 5px;
  background: #342f67;
}
.footer-social-link img {
  width: 25px;
  height: 25px;
}
.footer-link {
  color: #ddd;
  font-size: 14px;
  margin-right: 15px;
}
</style>

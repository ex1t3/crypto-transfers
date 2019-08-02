<template>
  <b-container>
    <b-row>
      <div class="col-sm-12">
        <h2>Frequently Asked Questions</h2>
      </div>
    </b-row>
    <b-row>
      <div class="offset-md-2 col-sm-12 col-md-8">
        <div role="tablist">
          <b-card no-body class="mb-1">
            <b-card-header class="toggle-header" header-tag="header" role="tab">
              <div v-b-toggle.faq1>Q: How do I use your system to transfer money?</div>
            </b-card-header>
            <b-collapse id="faq1" visible accordion="my-accordion" role="tabpanel">
              <b-card-body>
                <p class="card-text">
                  A: First of all you have to become a member of ISLB.
                  Then just log in into our system and proceed to transfer form for exchanging.
                </p>
              </b-card-body>
            </b-collapse>
          </b-card>
          <b-card no-body class="mb-1">
            <b-card-header class="toggle-header" header-tag="header" role="tab">
              <div v-b-toggle.faq2>Q: Is your system able to make transfers between different currencies?</div>
            </b-card-header>
            <b-collapse id="faq2" accordion="my-accordion" role="tabpanel">
              <b-card-body>
                <p class="card-text">A: We accept 4 types of crypto currencies: <strong>Bitcoin, Litecoin, Ethereum</strong> and <strong>Dash</strong>. 
                    You can transfer any amount not less than a 1 $ in any of above crypto currencies.</p>
              </b-card-body>
            </b-collapse>
          </b-card>
          <b-card no-body class="mb-1">
            <b-card-header class="toggle-header" header-tag="header" role="tab">
              <div v-b-toggle.faq3>Q: How much should I pay for your service?</div>
            </b-card-header>
            <b-collapse id="faq3" accordion="my-accordion" role="tabpanel">
              <b-card-body>
                <p class="card-text">A: We have a stable price for our clients and customers who trasnfer crypto to dollars using ISLB engine.
                    For every transfer client has to pay us <strong>20$</strong> not depending of an amunt of total user's transfer</p>
              </b-card-body>
            </b-collapse>
          </b-card>
          <b-card no-body class="mb-1">
            <b-card-header class="toggle-header" header-tag="header" role="tab">
              <div v-b-toggle.faq4>Q: How long the transaction is being executed?</div>
            </b-card-header>
            <b-collapse id="faq4" accordion="my-accordion" role="tabpanel">
              <b-card-body>
                <p class="card-text">All our transactions are started right after the client sends a transfer request. After that we send request to the bank, which can take up to <strong>3-7</strong> working days depending on bank's current work state.</p>
              </b-card-body>
            </b-collapse>
          </b-card>
        </div>
      </div>
    </b-row>
  </b-container>
</template>
<style scoped>
.toggle-header {
  text-align: left;
  cursor: pointer;
  font-weight: 500;
  border-bottom: none;
}
.card-text {
  text-align: left;
  font-weight: 300;
}
.card {
  box-shadow: 0px 10px 20px #dddddda6;
  border: none;
}
</style>


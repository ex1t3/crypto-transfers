<template>
  <div>
    <Title :name="$parent.titleObj.name" :lastUpdate="$parent.titleObj.lastUpdate" :downloadLink="$parent.titleObj.downloadLink" />

    <p>
      This is an agreement between ISLB OU (collectively referred to herein as “ISLB”, “we”, “us”, or “our”) and you (together with ISLB, the “Parties” and each a “Party”).
      By using any ISLB service, whether through islb.one, any associated website, API, or mobile application, you agree that you have read, understood, and accept all of the terms and conditions contained herein (the “User Agreement”),
      as well as our Privacy Policy available at
      <a href="https://www.islb.one/legal/privacy">https://www.islb.one/legal/privacy</a>,
      Cookie Policy, available at
      <a href="https://www.islb.one/legal/cookies">https://www.islb.one/legal/cookies</a>, API Agreement, available at
      <a href="https://www.islb.one/legal/api-terms">https://www.islb.one/legal/api-terms</a>.
    </p>

    <h5>
      THIS AGREEMENT CONTAINS AN ARBITRATION PROVISION. IF YOU ARE A U.S. PERSON AND WE CANNOT RESOLVE A DISPUTE THROUGH OUR USER OPERATIONS TEAM, ALL DISPUTES ARISING UNDER THIS USER AGREEMENT SHALL BE SETTLED IN BINDING ARBITRATION AS SET FORTH IN SECTION 15.
      ENTERING INTO THIS AGREEMENT CONSTITUTES A WAIVER OF YOUR RIGHT TO A TRIAL BY JURY AND PARTICIPATION IN A CLASS ACTION LAWSUIT.
    </h5>

    <h5>1. DEFINITIONS</h5>
    <p class="list-type">
      <b>EEA</b> (European Economic Area) – the single economic area comprising the Member States of the European Union and the three EFTA countries: Norway, Iceland and Liechtenstein.
    </p>
    <p class="list-type">
      <i>“Airdrop Program”</i> means the provision of virtual currency by ISLB OU at no cost and on the terms set forth in Section 8.
    </p>
    <p class="list-type">
      <i>“API”</i> means application programming interface, is not a Service and is governed by a separate agreement.
    </p>
    <p class="list-type">
      <i>"Fork"</i> means a change to the underlying protocol of a Virtual Currency network that results in more than one version of a Virtual Currency, the result of which may be one or more versions that are not supported by ISLB.
    </p>
    <p class="list-type">
      <i>“ISLB Site”</i> means the webpages and information available via islb.one and any ISLB mobile application.
    </p>
    <p class="list-type">
      <i>“Compliance Program”</i> means the requirements set by ISLB for collecting, verifying, recording and reporting information about you, upon first accessing certain Services and on an ongoing basis, whether for our business risk-management purposes or to comply with legal requirements applicable to us.
    </p>
    <p class="list-type">
      <b>Representative</b> - a natural person (e.g. member of the management board) entitled to use the Service or a natural person authorized by the latter to use the Service entered on the registration card of the legal entity.
    </p>
    <p class="list-type">
      <b>European payment</b> - a payment in the SEPA area.
    </p>
    <p class="list-type">
      <b>Personal identification</b> - a procedure performed by the Payment Intermediary in which the Payment Intermediary identifies and checks the Client’s claim of identity. The Payment Intermediary, inter alia, uses IT tools to identify a person.
    </p>
    <p class="list-type">
      <b>Terms and Conditions</b> - these Terms of Service and the Privacy Policy Terms and Conditions in addition to these User’s Terms and Conditions.
    </p>
    <p class="list-type">
      <b>Client</b> - at least 18 years of a natural person or a legal person who has agreed to these User’s Terms and Conditions and the User has used or has requested assistance from the Intermediary Service to use the Service. The Client who is a natural person uses the Service for personal use.
    </p>
    <p class="list-type">
      <b>Third person</b> - a natural or legal person who is not a Party in these User’s Terms and Conditions.
    </p>
    <p class="list-type">
      <b>Correspondent Bank</b> - the contractual partner of the Payment Intermediary through which the Payment Intermediary carries out euro payments.
    </p>
    <p class="list-type">
      <b>Cryptocurrency</b> - the virtual value accepted by the Payment Intermediary which the Client has paid to the Payment Intermediary’s Interim Account for making the Payment Transaction and which the Payment Intermediary converts to euros. The list of Cryptocurrencies accepted by the Payment Intermediary is available on the Portal.
    </p>
    <p class="list-type">
      <b>Limit</b> - the maximum amount that the Payment Intermediary has set for the Client’s Payment Transactions, within which the Client can make payments in euros
    </p>
    <p class="list-type">
      <b>Payment Order</b> - a form specified by the Payment Intermediary and filled by the Client to initiate a Payment Transaction.
    </p>
    <p class="list-type">
      <b>Payment Transaction</b> - the order given by the Client to the Payment Intermediary on the basis of the Payment Order for conversion of Cryptocurrency into euros and for transferring it to the Beneficiary's account.
    </p>
    <p class="list-type">
      <b>Payment Intermediary</b> - ISLB OÜ, reg. no. 14462613, operating licences: FRK000092 and FVR000112, address Parnu mnt 158, 11317 Tallin, Estonia, email info@islb.one.
    </p>
    <p class="list-type">
      <b>Other payment</b> - payment that is other than European payment.
    </p>
    <p class="list-type">
      <b>Banking Day</b> - a calendar day that is not a Saturday, a Sunday, a national or a public holidays.
    </p>
    <p class="list-type">
      <b>PEP</b> (Politically Exposed Person) - a natural person who fulfills or has fulfilled important public authority functions. A person who has not fulfilled the essential functions of a public authority for at least a year is not deemed a politically exposed person.
    </p>
    <p class="list-type">
      <b>Party or Parties</b> – under these Terms and Conditions, separately the Client or the Payment Intermediary or jointly the Client and the Payment Intermediary.
    </p>
    <p class="list-type">
      <b>Portal</b> - a web-based online payment environment for the Payment Intermediary at
      <a href="https://www.islb.one">https://www.islb.one</a> , through which Clients can use the Service, communicate with the Payment Intermediary, and perform other activities.
    </p>
    <p class="list-type">
      <i>“Virtual Currency”</i> means a cryptocurrency, digital currency, digital asset, crypto asset or other such similar term describing, for example, Bitcoin or Ether but does not include a derivative of a virtual currency, or a security, as defined under applicable law.
    </p>
    <p class="list-type">
      <i>“Wallet”</i> means the wallet software published by ISLB OU, consisting of software that permits you to self-custody virtual currency, organize network addresses, view transaction history and transact in virtual currencies as set forth in Section 5.
    </p>
    <p class="list-type">
      <b>Beneficiary</b> - the payee (natural or legal person) to whom the Client wishes to transfer money with the Payment Transaction.
    </p>
    <p class="list-type">
      <b>Beneficiary's account</b> - the bank account number corresponding to the IBAN standard registered on behalf of the Beneficiary in the credit institution of the Beneficiary’s country.
    </p>
    <p class="list-type">
      <b>SEPA</b> - Single Euro Payments Area which includes European Union countries plus Norway, Iceland, Liechtenstein, Switzerland and Monaco.
    </p>
    <p class="list-type">
      <b>Amount</b> - the monetary value in euros that the Client has indicated in the Payment Order, i.e. the money that the Client wishes to transfer to the Beneficiary's account.
    </p>
    <p class="list-type">
      <b>Service/transaction</b> - means one or more of the following services offered or provided by ISLB via website or local application (mobile, desktop, or otherwise), including the Wallet, intermediation by the Payment Intermediary, in accordance with these Terms and Conditions and via the Portal, the payments available for the Client, in the course of which the Payment Intermediary performs the Payment Transaction on the basis of the Payment Order.
    </p>
    <p class="list-type">
      <b>Service fee</b> - the fee payable by the Client to the Payment Intermediary for the execution of a Payment Transaction. Fee rates are available in the Portal.
    </p>
    <p class="list-type">
      <b>Actual beneficiary</b> - a natural person who exercises control over a transaction, action or another person, and in whose benefit, profit or account the transaction or action is performed.
    </p>
    <p class="list-type">
      <b>Intermediate account</b> - the address of the Cryptocurrency wallet of the Payment Intermediary that the Payment Intermediary uses for the execution of a Payment Transaction.
    </p>
    <p class="list-type">
      <b>Exchange rate</b> - the price of the Cryptocurrency which is the basis for the Payment Transaction, expressed in euros.
    </p>
    <p class="list-type">
      <b>Video identification</b> – a type of identification that allows the Payment Intermediary to identify the Client’s person. In the course of video identification, the Payment Intermediary conducts a video interview with the Client. Preconditions for the video identification are a computer with Internet access, a working webcam and a microphone.
    </p>
    <p class="list-type">
      <b>Business relationship</b> - the relationship between the Payment Intermediary and the Client, based on these User’s Terms and Conditions, under which the Payment Intermediary provides the Service to the Client in the course of its economic and professional activities. The beginning of a business relationship is the moment when the Client has provided the Payment Intermediary with the information required by the latter and has confirmed the acceptance of these terms and conditions.
    </p>
    <p class="list-type">
      <b>Transfer fee</b> - a service fee charged by the Correspondent Bank, which the Client undertakes to pay. Transfer rates are available on the Portal.
    </p>

    <h5>2. GENERAL USE</h5>
    <p>
      2.1
      <i>Eligibility</i>. By using the ISLB Site and entering into this User Agreement, you affirm that you are an individual, at least 18 years of age or older, have the capacity to enter into this User Agreement and agree to be legally bound by the terms and conditions of this User Agreement, including the Cookie Policy, the Privacy Policy and the Trading Principles as incorporated herein, as amended from time to time. In order to use the Services, you may be required to provide certain identifying information pursuant to our Compliance Program.
    </p>

    <p>
      2.2
      <i>Modification</i>
    </p>
    <p>2.2.1 We may change the terms of this User Agreement at any time. Any such changes shall take effect when posted on the ISLB Site, or when you use the Services. If you have supplied us with an email address, we shall also attempt to notify you by email of changes to this User Agreement. If you disagree with any changes to this User Agreement, contact us.</p>

    <p>2.2.2 It is your responsibility to update your contact information, including but not limited to the email address provided to us (if any); failure to do so may result in you not receiving notice of any such changes to the User Agreement.</p>

    <p>2.2.3 Read the User Agreement carefully on each occasion you use the Services. Your continued use of the Services shall signify your acceptance to be bound by the current User Agreement. Our failure or delay in enforcing or partially enforcing any provision of this User Agreement shall not be construed as a waiver of any of our rights.</p>

    <h5>3. COMPLIANCE WITH APPLICABLE LAW</h5>
    <p>Your relationship with ISLB and use of any of the Services may be subject to the laws, regulations, and rules of governmental or regulatory authorities in your or our jurisdiction (“Applicable Law”). By entering into this User Agreement, you agree to act in compliance with and be legally bound to any and all Applicable Law.</p>

    <h5>4. ACCESSING THE SERVICES</h5>
    <p>
      4.1
      <i>Limited License</i>. We grant you a limited, nonexclusive, nontransferable license to access and use the Services and the ISLB Site solely in accordance with the terms of this Agreement.
    </p>
    <p>
      4.2
      <i>Credentials</i>. You must keep secret all credentials associated with the Services. You are solely responsible for managing and maintaining the security of any information relating to such credentials and agree that ISLB shall not be held responsible (and you shall not hold us responsible) for any unauthorized access to the Services or any resulting harm you may suffer.
    </p>
    <p>
      4.3
      <i>Compliance</i>. Your access to one or more Services may be contingent upon satisfaction of our onboarding processes as well as our Compliance Program, which may include verification of your identity and source of funds, and additional information we may request from time-to-time. The information we request may include, without limitation, personally identifiable information such as network address, name, email, address, telephone number, date of birth, taxpayer identification or social security number, official government-issued photo identification, and bank account information or other information we may reasonably deem helpful in satisfying our risk management or legal obligations. In providing this information to us you represent that it is accurate and agree to update your User Account information promptly, but in no event later than 14 days following any change in your information. Failure to provide information or update it promptly may result in Services or funds being unavailable to you.
    </p>
    <p>
      4.4
      <i>Communications</i>. Any and all communications from ISLB may be provided to you via electronic mail at the address you provided when accessing the Services. ISLB shall not be responsible for any harm you may suffer as a result of your failure to receive any notice provided to you in connection with this User Agreement or your use of Services so long as such notice is provided to such email address. ISLB may also communicate with you through other methods, including via telephone call, instant messaging or chat applications either operated by ISLB or a third party.
    </p>
    <p>
      4.5
      <i>Termination</i>. We may close, terminate, enable or disable any or all of the Services, your User Account or your access to the Services at any time and for any reason. You may close your User Account at any time and for any reason. Depending on the Services available to you in your User Account, we may require you to take certain actions in order to complete a pending transaction or provide additional information prior to closing such User Account. You are solely responsible for any fees already incurred or associated with the closing of your User Account, whether incurred directly by you from ISLB, or incurred by ISLB on your behalf with a third party in order to complete any such action. Closing your User Account may not result in the deletion of information we hold about you or your activity.
    </p>
    <h5>5. THE WALLET</h5>
    <p>
      5.1
      <i>Description</i>
    </p>
    <p>5.1.1 The Wallet is provided to you exclusively by ISLB OU at no point will ISLB ever take custody of Virtual Currency stored in a Wallet. The Wallet is only capable of supporting certain Virtual Currencies. Under no circumstances should you attempt to store Virtual Currencies in your Wallet that the Wallet does not support.</p>
    <p>
      5.1.2 When you create a Wallet, the Wallet software generates a cryptographic private and public key pair that you may use to send and receive any supported Virtual Currency via the relevant Virtual Currency network.
      <b>YOU MUST STORE, OUTSIDE OF THE SERVICES, A BACKUP OF ALL WALLET CREDENTIALS, INCLUDING YOUR PASSPHRASES, IDENTIFIERS, BACKUP PHRASES, PRIVATE KEYS AND NETWORK ADDRESSES.</b> If you do not maintain a backup of your Wallet data outside of the Services, you will not be able to access Virtual Currency previously accessed using your Wallet in the event that we discontinue or no longer offer some or all of the Services or may otherwise lose access to Virtual Currency. We are not responsible for maintaining this data on your behalf.
    </p>
    <p>
      5.2
      <i>Risk Disclosures Relating to the Wallet</i>.
    </p>
    <p>5.2.1 In order to be completed, any Virtual Currency transaction created with the Wallet must be confirmed and recorded in the Virtual Currency ledger associated with the relevant Virtual Currency network. Such networks are decentralized, peer-to-peer networks supported by independent third parties, which are not owned, controlled or operated by ISLB.</p>
    <p>5.2.2 ISLB has no control over any Virtual Currency network and therefore cannot and does not ensure that any transaction details you submit via our Services will be confirmed on the relevant Virtual Currency network. The transaction details you submit via our Services may not be completed, or may be substantially delayed, by the Virtual Currency network used to process the transaction. We do not guarantee that the Wallet can transfer title or right in any Virtual Currency or make any warranties whatsoever with regard to title.</p>
    <p>5.2.3 Once transaction details have been submitted to a Virtual Currency network, we cannot assist you to cancel or otherwise modify your transaction or transaction details. ISLB has no control over any Virtual Currency network and does not have the ability to facilitate any cancellation or modification requests.</p>
    <p>
      5.3
      <i>Forks</i>. In the event of a Fork or other network disruption, ISLB may not be able to support activity related to your Virtual Currency. In the event of a Fork, the transactions may not be completed, completed partially, incorrectly completed, or substantially delayed. ISLB is not responsible for any loss incurred by you caused in whole or in part, directly or indirectly, by a Fork or other network disruption.
    </p>
    <p>
      5.4
      <i>No Password Retrieval</i>.
    </p>
    <p>5.4.1 With respect to the Wallet, ISLB does not receive or store your Wallet password, nor any keys, network addresses or transaction history. We cannot assist you with Wallet password retrieval. You are solely responsible for remembering, storing and keeping secret your Wallet password. Any Virtual Currency you have associated with such Wallet may become inaccessible if you do not know or keep secret your Wallet password. Any third party with knowledge of one or more of your credentials (including, without limitation, a backup phrase, wallet identifier or password) can dispose of Virtual Currency in your Wallet.</p>
    <p>5.4.2 When you create a Wallet, you must: (a) create a strong password that you do not use for any other website or online service; (b) provide accurate and truthful information; (c) protect and keep secret all credentials for the Wallet; (d) protect access to your device and your Wallet; (e) promptly notify us if you discover or otherwise suspect any security breaches related to your Wallet; and (f) use the backup functionality provided through the Wallet and safeguard your backup files. You agree to take responsibility for all activities that occur with your Wallet and accept all risks of any authorized or unauthorized access to your Wallet, to the maximum extent permitted by law.</p>
    <p>
      5.5
      <i>Fees</i>. ISLB may charge a fee for the Wallet sending or controlling Virtual Currency. We reserve the right to do in the future, and in such case shall display to you any applicable fees prior to you incurring the fee. Network fees (including, without limitation “miner’s fees”) required to use a Virtual Currency network may apply to a transaction. We may attempt to calculate such a fee for you. Our calculation may not be sufficient, or it may be excessive. You may select a greater or lesser fee. You are solely responsible for selecting and paying any such fee and ISLB shall neither advance nor fund such a fee on your behalf, nor be responsible for any excess or insufficient fee calculation.
    </p>
    <h5>6. THE SERVICE</h5>
    <p>
      6.1.
      <i>General information</i>
    </p>
    <p>Our Services consist of facilitating Account holders request to buy/sell/exchange of digital currencies such as Bitcoins. Service fee for exchange is 4% and is incorporated to the final amount user is willing to pay. ISLB does not keep or manage any fiat deposits.</p>
    <p>Our policy to comply with applicable laws and regulations regarding AML and identity verification (know your customer / KYC procedures), and to detect and prevent the use of our Services for money laundering or to facilitate criminal or terrorist activities.</p>
    <p>For the avoidance of doubt, we do not provide any investment advice in connection with the Services contemplated by these Terms of Use. We may provide information on the price, range, volatility of digital currencies and events that have affected the price of these, but this is not considered investment advice and should not be construed as such. Any decision to purchase or sell digital currency is your decision and we will not be liable for any loss suffered.</p>
    <p>
      6.2.
      <i>Buy digital currencies: via online instant payment service and bank transfer.</i>
    </p>
    <p>A buy transaction is initiated after your payment notification has been received from our payment service provider and is processed by ISLB. The digital currency will be sent to the digital currency address of your wallet after finishing the buy transaction. The digital currency price for your transaction will be locked in for a short period, so you know exactly how much digital currency you will receive. If your payment takes more than the lock in period to finalize, your digital currency price will be updated with the ISLB Offer Price at the time of receiving your payment signal. In that case the final amount of digital currency sent to your wallet may differ slightly. The minimum and maximum transaction sizes depend on the status of your Account and are visible at Payment Verification window.</p>

    <p>When buying digital currency by SEPA bank transfer, you acknowledge and agree to accept:</p>
    <p
      class="list-type"
    >That you will be provided with the details of the ISLB bank account after clicking the review order button on the Payment verification (Buy) page.</p>
    <p
      class="list-type"
    >SEPA bank transfers are processed daily after receiving a notification from our bank of your transfer. Expect a lead time of one to three working days between your bank transfer and receiving the digital currency in your wallet.</p>
    <p
      class="list-type"
    >Initiate your SEPA transfer from the bank account, which is under the same name you used to complete verification on ISLB account.</p>
    <p
      class="list-type"
    >Put your ISLB payment reference in the 'comment' (sometimes called 'label' or 'reference') field of the bank transaction.</p>
    <p
      class="list-type"
    >Only transfer Euro amounts within the limits of your ISLB Account and the exact amount you saw on the payment verification window.</p>
    <p
      class="list-type"
    >If you transfer money, but your ID verification has failed - please start the verification process again through elastum.io or write email to support@islb.one and ask for help. If within 10 working days you will not complete verification successfully because of the issues from your side, ISLB is responsible to take 10% fee from the amount you sent (with minimum of 5 euros and maximum of 20 euros). The amount will be transferred to the same IBAN account the transfer was made to ISLB.</p>
    <p
      class="list-type"
    >If you transfer the amount which exceeds the one you have to pay based on the order you accepted - ISLB will exchange crypto currencies for the amount you have transferred with the updated amount/volume of digital asset you have selected.</p>
    <p
      class="list-type"
    >The minimum SEPA transfer is equal to 30 euros and the maximum depends on your account level of your ISLB Account.</p>
    <p
      class="list-type"
    >After your SEPA bank transfer, it usually takes 1-5 working days to show on our bank account.</p>
    <p
      class="list-type"
    >Once our bank confirms your transfer, we initiate a buy transaction and the digital currency will be sent to your blockchain wallet address.</p>
    <p
      class="list-type"
    >The estimated amount of digital currency on the Offer details page is based on the market price at that moment.</p>
    <p
      class="list-type"
    >The final amount of digital currency you receive will differ from the estimate as the price is determined when your order is actually traded, this means - when your bank transfer is received.</p>
    <p
      class="list-type"
    >The final exchange selection will depend on the market situation and exchange availability at the time your order transaction is processed.</p>
    <p
      class="list-type"
    >When your digital currency is sent to your wallet you will receive a confirmation email with the financial transaction details.</p>

    <p>
      6.3.
      <i>Payment transaction</i>
    </p>
    <p>(i) The Service offered by the Payment Intermediary is payment intermediation in which the Payment Intermediary converts the Cryptocurrency into euros and executes the Payment Transaction specified in the Payment Order. (ii) Payments are executed through the Correspondent Bank, in accordance with the agreement concluded between the Correspondent Bank and the Payment Intermediary. (iii) Payments can be made to credit institutions of such countries that have adopted account numbers corresponding to the IBAN standard. The list of such countries is available on the Portal.</p>

    <p>
      6.3.1.
      <i>The Client shall:</i>
    </p>
    <p>Complete the Payment order:</p>
    <p class="list-type">Beneficiary name (required);</p>
    <p class="list-type">Beneficiary account (required);</p>
    <p class="list-type">Amount in euros (required);</p>
    <p class="list-type">Reference number (required, if not indicated);</p>
    <p class="list-type">Explanation (required if reference number is not indicated).</p>
    <p class="list-type">Selects the cryptocurrency in which the Client wishes to make a payment;</p>

    <p>Enter the Client’s details:</p>
    <p class="list-type">First and last name;</p>
    <p class="list-type">E-mail address.</p>
    <p
      class="list-type"
    >Confirms the acceptance with the User’s Terms and Conditions and the Privacy Policy’s Terms and Conditions;</p>
    <p class="list-type">Confirms the accuracy of the submitted data;</p>

    <p>Within 30 minutes after the acceptance referred to in clause “Confirms the accuracy of the submitted data” (it is not possible to add the missing amount later) performs the Cryptocurrency payment from the Client’s wallet address in the currency indicated by the Payment Intermediary to the Payment Intermediary’s Intermediate Account.</p>

    <p>
      6.3.2.
      <i>The Payment Intermediary shall:</i>
    </p>
    <p>Exchange the Cryptocurrency received from the Client into euros in accordance with the current exchange rate;</p>
    <p>Forward the Payment Order to the Correspondent Bank, which executes the Transaction Receipt and Account on the basis of the Payment Order.</p>

    <p>
      6.4.
      <i>Due dates</i>
    </p>
    <p>Conversion of the Cryptocurrency to the euro by the Payment Intermediary and the transfer of the Payment Order to the Correspondent Bank - 1 (one) Banking Day;</p>
    <p>Approval of the Payment Order by the Correspondent Bank and execution of the Payment Transaction - from 1 (one) to 7 (seven) Banking Days, depending on the type of payment:</p>
    <p class="list-type">European payment - from 1 (one) to 3 (three) Banking Days;</p>
    <p class="list-type">Other taxes – from 3 (three) to 7 (seven) Banking Days.</p>
    <p
      class="list-type"
    >The terms specified in clause “Approval of the Payment Order by the Correspondent Bank” do not apply if for circumstances beyond the control of the Payment Intermediary, the Correspondent Bank has rejected, cancelled, suspended, etc. the Payment Transaction (clause “Repayment initiated”).</p>

    <p>
      6.5.
      <i>Transaction statuses</i>
    </p>
    <p>
      <b>Archived</b> - archived (Payment Transaction has been accepted and the Payment Intermediary has deemed it to be concluded).
    </p>
    <p>
      <b>Cancelled</b> - cancelled (Cryptocurrency has not been received within the specified term specified in clause 6.3.1.);
    </p>
    <p>
      <b>Confirmed by bank</b> - confirmed (The Payment Transaction is accepted by the Correspondent Bank and the Amount is being transferred to the Beneficiary's account);
    </p>
    <p>
      <b>Full</b> – being processed (Cryptocurrency is received in the correct amount and the Payment Order is executed by the system for the execution of the Payment Transaction);
    </p>
    <p>
      <b>Full with exception</b> – being processed with an exception (Cryptocurrency has been received in higher or lower amount and, according to its value, the Payment Order has been generated by the system for execution of a Payment Transaction);
    </p>
    <p>
      <b>Incomplete</b> - inadequate payment (Cryptocurrency was received in lower amount, i.e. after conversion, its monetary value in euros is lower than the Amount stated in the Payment Order);
    </p>
    <p>
      <b>New</b> - initiated (the Client has confirmed the execution of the Cryptocurrency payment and forwarded the Payment Order to the Payment Intermediary);
    </p>
    <p>
      <b>Prepared for bank</b> - prepared (the Payment Order is prepared for the Correspondent Bank and is waiting to be transferred to the Correspondent Bank);
    </p>
    <p>
      <b>Repayment initiated</b> - rejected (Payment Transaction has been rejected by the Correspondent Bank due to incorrect IBAN, invalid or telephone number etc.);
    </p>
    <p>
      <b>Sent to bank</b> – being confirmed (the payment order has been submitted to the Correspondent bank for Confirmation);
    </p>
    <p>
      <b>Unconfirmed incoming</b> – in processing (Cryptocurrency is on the way, but has not yet arrived at the Intermediate Account).
    </p>

    <p>
      6.6.
      <i>Cancellation of a transaction</i>
    </p>
    <p>In case the Cryptocurrency payment has not reached the Payment Intermediary's Intermediate Account by the terms specified in clause 6.3.1, the Payment Intermediary shall cancel the Transaction.</p>
    <p>In the event of any technical failure (eg lack of connection to the Exchange rate provider, etc.) that does not allow the Bank to complete the Transaction, the Payment Intermediary shall cancel the Transaction and immediately notify the Client via e-mail.</p>
    <p>In the event that the Transaction reveals an identity for which the Payment Intermediary needs additional information or documents, it shall forward the relevant e-mail to the Client. In case the Client does not submit the information or documents required by e-mail within the time period prescribed, the Payment Intermediary cancels the Transaction, informing the Client without delay by e-mail.</p>
    <p>Upon cancellation of a payment transaction in accordance with upper clauses in this section, the Payment Intermediary shall return the Cryptocurrency received by the Client to the Client’s Wallet, less the Service Fee, within 1 (one) Banking Day.</p>
    <p>Upon cancellation of a Payment Transaction on the basis provided in this section, the Payment Intermediary shall within 1 (one) Banking Day return the Cryptocurrency paid by the Client to the Client’s Wallet address without deducting the Service Fee.</p>
    <p>
      6.7.
      <i>Excess payment</i>
    </p>
    <p>In case the Client has transferred to the Payment Intermediary’s Intermediary Account a larger amount than required for executing the Payment Order, the Payment Intermediary shall forward notify the Client by e-mail and return the Cryptocurrency paid by the Client less the Service Fee and Transfer Fee to the Client’s Wallet within 1 (one) Banking Day.</p>
    <p>In case if the Overpayment minus the Service Fee and Transfer Fee is less than or equal to 3 (three) Euro, the Overcharge will not be returned to the Customer and the information about the Customer will not be sent by e-mail.</p>
    <p>
      6.8.
      <i>Missing payment</i>
    </p>
    <p>In case the Client has transferred to the Payment Intermediary’s Intermediary Account a smaller amount of Cryptocurrency that required for the execution of the Payment Transaction, the Payment Intermediary executes the Payment Transaction, but at such a value that corresponds to the alue of the received amount of Cryptocurrency less the Service Fee and Transfer Fee. The Payment Intermediary notifies the Client without delay by e-mail about the Payment Transaction made on the basis of a defective payment.</p>

    <p>
      6.9.
      <i>Other important information</i>
    </p>
    <p>The exchange rate is fixed upon confirmation of the payment by the Client.</p>
    <p>In case of cancellation of the Transaction and in case of Excess Payment, the Payment Intermediary notifies the Client without delay by e-mail, except as specified in clause 6.6.</p>
    <p>All repayments to the Client are made in the same Cryptocurrency as the Client submitted to the Payment Intermediary, i.e. the Payment Intermediary does not execute payments in another virtual currency or euro or other currency payments.</p>
    <p>The Payment Intermediary shall perform all Cryptocurrency repayments to the Wallet Address notified by the Client to the Payment Intermediary. In case the Client has notified to the Payment Intermediary an invalid Wallet Address, the Payment Intermediary shall not be responsible for non-receipt of the Cryptocurrency.</p>
    <p>The Payment Intermediary shall transmit all notifications to the Client by e-mail in English and the Client shall be responsible for ensuring that the notified e-mail address is correct.</p>
    <p>In case the Client has started performing the Transaction, but shall not transfer the required amount of Cryptocurrency to the Payment Intermediary’s Intermediate Account, i.e. does not complete the Transaction, the Transaction is deemed to have not been carried out and shall have no legal consequences.</p>
    <p>Payment Transactions are automatically executed by the Payment Intermediary’s system in accordance with the set criteria. In case the Payment Intermediary has doubts about the purpose, content, amount of the Transaction, etc. the Transaction shall be executed manually and the Payment Intermediary shall execute the Transaction after receiving confirmation from the Client or from other sources that the Transaction is legitimate and compliant. In the above case, the term for the Payment Transaction may be extended and may be longer than the term indicated in the clause 2.3.</p>
    <p>The Transaction that has the status Sent to Bank, Confirmed by bank or Archived is irreversible and cannot be cancelled or recalled.</p>
    <p>The Payment Intermediary is obliged to suspend, cancel or recall the Transaction at the request of a competent authority (e.g., Correspondent Bank, competent authorities). In this case, the Client shall cooperate with the Payment Intermediary to clarify the circumstances on which the application is based. In the above case, the term for the implementation set out in clause 6.4 do not apply.</p>

    <h5>7. PERSONAL IDENTIFICATION</h5>
    <p>In accordance with applicable laws and regulations regulating money laundering or terrorist financing, the Payment Intermediary shall collect sufficient data from the Client during the establishment and in the course of the business relationship, which, inter alia, would allow the Payment Intermediary to identify and check the Client's identity and the purpose of the Transaction.</p>
    <p>At the request of the Payment Intermediary, either through the questionnaire or video interview, the Client is obliged to submit/provide additional data and information for the Transaction, which include, inter alia:</p>
    <p class="list-type">date of birth (day, month and year);</p>
    <p class="list-type">residential address;</p>
    <p class="list-type">citizenship;</p>
    <p
      class="list-type"
    >name of the identity document accepted by the Payment Intermediate, number, date of issue, name of issuer (The list of identity documents accepted by the Payment Intermediary is available on the Portal);</p>
    <p class="list-type">a copy of the identity document including a face image;</p>
    <p class="list-type">profession or field of activity;</p>
    <p class="list-type">wallet address;</p>
    <p
      class="list-type"
    >information on whether a person is a close associate or family member of a PEP;</p>
    <p
      class="list-type"
    >data on the Actual Beneficiary, incl. information relating to companies related to a sole proprietor;</p>
    <p class="list-type">name and registry code of the legal entity;</p>
    <p
      class="list-type"
    >Country of residence of the legal entity, name and web address in the country of registration;</p>
    <p
      class="list-type"
    >An up-to-date copy of the legal entity in the country of registration, which may include the details of the legal representative;</p>
    <p class="list-type">Postal address of the legal entity;</p>
    <p>Identity of the representative of the legal entity.</p>
    <p>A legal entity will use the Service through its Representative. In case the Representative is an authorized person, a notarized and apostilled document/power of attorney must be submitted at the request of the Payment Institution.</p>
    <p>For personal identification and verification, the Payment Intermediary makes enquiries to trusted, independent registers and databases on the basis of personal data and copies of documents transmitted by the Client.</p>
    <p>The Payment Intermediary has the right at any time to request from the Client to submit his or her data, incl. the source of wealth and the purpose of the business, to supplement the data and documents.</p>
    <p>In the event that the Client does not submit the required documents or submits false information, it is treated as a fraud and the Payment Intermediary is required to suspend the provision of the Service and immediately transmit the relevant information to the competent authority.</p>
    <p>The Payment Transaction Limit set by the Payment Intermediary for the Client depends on the level of risk assigned to the Client Profile and the amount of Transaction(s) established in the Payment Intermediary’s Internal Rules of Payment.</p>
    <p>Depending on the risk profile and the Transaction amount, the Client, at the request of the Payment Intermediary, must perform additional personal identification in one of the following ways:</p>
    <p>The Client sends to the Payment Intermediary in a legible and comprehensible format a copy of a utility bill in his/her place of residence/domicile, bank certificate, tax return, or other document that includes the Client’s name, address and date of issue, which may not be older than 3 (three) months.</p>
    <p>Video identification.</p>

    <h5>8. REQUIREMENTS FOR DOCUMENTS</h5>
    <p>Documents sent to the Payment Intermediary must meet the following requirements:</p>
    <p>Copy of an ID document:</p>
    <p class="list-type">in colour and clearly legible;</p>
    <p
      class="list-type"
    >may not contain fields or information that is partially or wholly hidden/covered;</p>
    <p
      class="list-type"
    >must be valid and the data indicated on it must completely coincide with the data that the Client has provided to the Payment Intermediary;</p>
    <p class="list-type">must be made in both documents;</p>
    <p class="list-type">must be in the form accepted by the Payment Intermediary (.jpg)/(.png).</p>

    <p>Utility bill, bank certificate, tax return, etc. document:</p>
    <p
      class="list-type"
    >must contain the Client’s name, address, the date of issue, the name of the document (invoice, driving license, etc.), data of the issuer of the document;</p>
    <p class="list-type">must not be older than 6 months;</p>
    <p
      class="list-type"
    >the address on the document must coincide with the data transmitted to the Payment Intermediary and may not be a mailing address;</p>
    <p class="list-type">must be in the format accepted by the Payment Intermediary (.jpg)/(.png).</p>

    <p>All documents must be presented separately (e.g., identity document and utility bill).</p>

    <h5>9. GENERAL RISK FACTORS</h5>
    <p>Your use of the Services requires you to bear risks for which we cannot be held responsible. We list some, but not all of these risks below:</p>
    <p
      class="list-type"
    >Hardware, software or connections required to interact with a Virtual Currency network might fail, succumb to malware, unauthorized access or malicious attacks. Third parties may obtain unauthorized access to the Services, including, but not limited to your public and private keys. ISLB shall not be responsible for any communication failures, disruptions, errors, distortions or delays you may experience when using the Services, however caused.</p>
    <p
      class="list-type"
    >Forks, unknown vulnerabilities in or unanticipated changes to the network protocol may cause losses to you or others. ISLB has no control over any cryptocurrency network and shall not be responsible for any harm occurring as a result of the inability to reverse a transaction, and any losses in connection therewith due to erroneous or fraudulent actions.</p>
    <p
      class="list-type"
    >The risk of loss of value in using Services involving Virtual Currencies may be substantial and losses may occur over a short period of time. In addition, price and liquidity are subject to significant fluctuations that may be unpredictable.</p>
    <p
      class="list-type"
    >Virtual Currencies are not legal tender and are not backed by any sovereign government. In addition, the legislative and regulatory landscape around Virtual Currencies is constantly changing and may affect your ability to use, transfer, or exchange Virtual Currencies.</p>
    <p
      class="list-type"
    >Virtual Currency transactions may not be reversible. Once you send Virtual Currency to an address, you may lose access to your Virtual Currency temporarily or indefinitely. For example, an address may have been entered incorrectly, or an address may belong to an entity that will not return your Virtual Currency. Virtual Currency mistakenly sent to an address we control may not be recoverable.</p>

    <h5>10. GENERAL PROVISIONS</h5>
    <p>
      10.1
      <i>Intellectual Property.</i>
    </p>
    <p>10.1.1. Unless otherwise indicated by us, all intellectual property rights and any content provided in connection with the ISLB Site or the Services, are the property of ISLB or our licensors or suppliers and are protected by applicable intellectual property laws. We do not give any implied license for the use of the contents of the ISLB Site or the Services.</p>
    <p>10.1.2 You accept and acknowledge that the material and content contained in or delivered by the ISLB Site or the Services is made available for your personal, lawful, non-commercial use only and that you may only use such material and content for the purpose of using the ISLB Site or the Services as set forth in this Agreement.</p>
    <p>10.1.3 You further acknowledge that any other use of content from the ISLB Site or the Services is strictly prohibited and you agree not to infringe or enable others to infringe our intellectual property rights. You agree to retain all copyrighted and other proprietary notices contained in the material provided via the ISLB Site or the Services on any copy you make of the material but failing to do so shall not prejudice ISLB’s intellectual property rights therein.</p>
    <p>10.1.4 You may not sell or modify materials derived or created from the ISLB Site or the Services or reproduce, display, publicly perform, distribute or otherwise use the materials in any way for any public or commercial purpose. Your use of such materials on any other website or on a file-sharing or similar service for any purpose is strictly prohibited. You may not copy any material or content derived or created from the ISLB Site or the Services without our express, written permission.</p>
    <p>10.1.5 Any rights not expressly granted herein to use the materials contained on or through the ISLB Site or the Services are reserved by ISLB in full.</p>
    <p>
      10.2
      <i>Accuracy of Information</i>.
    </p>
    <p>10.2.1 We endeavor to verify the accuracy of any information displayed, supplied, passing through or originating from the Services, but such information may not always be accurate or current. Accordingly, you should independently verify all information before relying on it, and any decisions or actions taken based upon such information are your sole responsibility.</p>
    <p>10.2.2 We make no representation or warranty of any kind, express or implied, statutory or otherwise, regarding the contents of the Services, information and functions made accessible through the Services, any hyperlinks to third party websites, or the security associated with the transmission of information through the Services, or any website linked to the Services.</p>
    <p>
      10.3
      <i>Third Party Services and Content</i>.
    </p>
    <p>10.3.1 In using the Services, you may view content or services provided by third parties, including links to web pages and services of such parties (“Third Party Content”). We do not control, endorse or adopt any Third Party Content and have no responsibility for Third Party Content, including, without limitation, material that may be misleading, incomplete, erroneous, offensive, indecent or otherwise objectionable in your jurisdiction. In addition, your dealings or correspondence with such third parties are solely between you and the third party.</p>
    <p>10.3.2 We are not responsible or liable for any loss or damage of any sort incurred as a result of any such dealings and your use of Third Party Content is at your own risk.</p>
    <p>
      10.4
      <i>Cooperation with Law Enforcement</i>. ISLB may, from time-to-time, respond to requests from third parties, courts, law enforcement, regulators and policymakers by producing certain information about or relating to your use of the Services.
    </p>
    <p>
      10.5
      <i>Recordkeeping</i>. Depending on the Services used by you, ISLB reserves the right, in our sole discretion, to create and maintain certain records of your activity and communications relating to your User Account.
    </p>

    <h5>11. FEEDBACK AND COMPLAINTS</h5>
    <p>
      11.1
      <i>Feedback</i>.
    </p>
    <p>11.1.1 ISLB strives to improve its Services to address feedback. If you have ideas or suggestions regarding improvements or additions to the Services, we would like to hear them; however, any submission shall be subject to this User Agreement.</p>
    <p>11.1.2 Under no circumstances shall disclosure of any idea or feedback, or any related material to ISLB be subject to any obligation of confidentiality or expectation of compensation.</p>
    <p>11.1.3 By submitting an idea or feedback or any related material that would be subject to intellectual property rights (the “Work”) to ISLB, you grant to ISLB, with respect to the Work submitted, a non-exclusive, perpetual, global, royalty-free license to use all of the content of such ideas and feedback, for any purpose whatsoever.</p>
    <p>11.1.4 By submitting Work, you are waiving any moral rights to the fullest extent permitted under law that you may have in the Work and are representing and warranting to ISLB that the Work originated with you, no one else has any rights in the Work, and that ISLB is free of any royalty to implement the Work and to use the related material if so desired, as provided or modified by ISLB, without obtaining permission or license from any third party</p>
    <p>11.1.5 ISLB may sub-license in any way all Work and material you have submitted to ISLB.</p>
    <p>
      11.2
      <i>Technical Support</i>. We shall use commercially-reasonable efforts to supply email-based technical support services, but cannot guarantee immediate responses, especially during times of high volume.
    </p>

    <h5>12. REPRESENTATIONS, WARRANTIES, INDEMNIFICATION AND LIMITATIONS OF LIABILITY</h5>
    <p>
      12.1
      <i>No Violation of Law</i>. You represent and warrant to us that you:
    </p>
    <p
      class="list-type"
    >are not located in, under the control of, or a resident of any Restricted Location or any country to which the United States has embargoed goods and services;</p>
    <p
      class="list-type"
    >are not identified as a “Specially Designated National” by the United States Treasury Department;</p>
    <p
      class="list-type"
    >shall not use the Services if you are prohibited by any applicable law, regulation, or rule from doing so.</p>
    <p>
      12.2
      <i>Acceptable Use of ISLB Services</i>.When accessing or using the Services, you agree that you are solely responsible for your conduct while accessing and using our Services. Without limiting the generality of the foregoing, you agree that you shall not:
    </p>
    <p
      class="list-type"
    >use the Services in any manner that could interfere with, disrupt, negatively affect or inhibit other users from fully enjoying the Services, or that could damage, disable, overburden or impair the functioning of our Services in any manner;</p>
    <p
      class="list-type"
    >use the Services to pay for, support or otherwise engage in any illegal activities, including, but not limited to illegal gambling, fraud, money laundering, or terrorist activities;</p>
    <p
      class="list-type"
    >use any robot, spider, crawler, scraper or other automated means or interface not provided by us to access our Services or to extract data;</p>
    <p
      class="list-type"
    >use or attempt to use another person’s User Account, or credentials without authorization;</p>
    <p
      class="list-type"
    >attempt to circumvent any content filtering techniques we employ, or attempt to access any service or area of our Services that you are not authorized to access;</p>
    <p
      class="list-type"
    >introduce to the Services any virus, Trojan, worms, logic bombs or other harmful material;</p>
    <p
      class="list-type"
    >develop any third-party applications that interact with our Services without our prior written consent;</p>
    <p class="list-type">provide false, inaccurate, or misleading information; or</p>
    <p
      class="list-type"
    >encourage or induce any other person to engage in any of the activities prohibited under this Section.</p>
    <p>
      12.3
      <i>Disclaimer of Warranties.</i> ISLB DISCLAIMS ANY AND ALL PROMISES, REPRESENTATIONS AND WARRANTIES, WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, DATA ACCURACY, SYSTEM INTEGRATION, TITLE, NON-INFRINGEMENT AND/OR QUIET ENJOYMENT, AND ANY SERVICES PROVIDED BY ISLB ARE PROVIDED “AS IS” AND “AS AVAILABLE.” EXCEPT AS EXPRESSLY PROVIDED HEREIN, YOU ACKNOWLEDGE THAT ISLB MAKES NO WARRANTIES UNDER THIS AGREEMENT DIRECTLY FOR THE BENEFIT OF ANY END USER, AND THAT ISLB’S OBLIGATIONS UNDER THIS AGREEMENT ARE FOR THE BENEFIT OF YOU ONLY, AND NOT FOR THE BENEFIT OF ANY OTHER PERSON. IN ENTERING INTO THIS AGREEMENT, YOU REPRESENT THAT YOU HAVE NOT RELIED UPON ANY REPRESENTATION OR WARRANTY OF ISLB OR ITS AFFILIATES EXCEPT AS EXPRESSLY SET FORTH IN THIS AGREEMENT. WE DO NOT MAKE ANY REPRESENTATIONS OR WARRANTIES THAT ACCESS TO THE SERVICES SHALL BE CONTINUOUS, UNINTERRUPTED, TIMELY, OR ERROR-FREE.
    </p>
    <p>
      12.4
      <i>Limitation of Liability.</i> IN NO EVENT SHALL ISLB, ITS AFFILIATES AND SERVICE PROVIDERS, OR ANY OF THEIR RESPECTIVE OFFICERS, DIRECTORS, AGENTS, EMPLOYEES OR REPRESENTATIVES, BE LIABLE FOR: (A) ANY AMOUNT GREATER THAN THE VALUE OF THE VIRTUAL CURRENCY ACTUALLY DELIVERED TO US BY YOU OR BY YOU TO US IN CONNECTION WITH A SUPPORTED VIRTUAL CURRENCY TRANSACTION COMPLETED ON ITS DISPLAYED TERMS OVER THE LAST SIX MONTHS, VALUED IN GREAT BRITISH POUNDS AT THE TIME OF THE TRANSACTION; OR (B) FOR ANY LOST PROFITS OR ANY SPECIAL, INCIDENTAL, INDIRECT, INTANGIBLE, OR CONSEQUENTIAL DAMAGES, WHETHER BASED IN CONTRACT, TORT, NEGLIGENCE, STRICT LIABILITY, OR OTHERWISE, ARISING OUT OF OR IN CONNECTION WITH AUTHORIZED OR UNAUTHORIZED USE OF THE SERVICES, OR THIS AGREEMENT, EVEN IF AN AUTHORIZED REPRESENTATIVE OF ISLB HAS BEEN ADVISED OF, KNEW OF, OR SHOULD HAVE KNOWN OF THE POSSIBILITY OF SUCH DAMAGES. FOR EXAMPLE (AND WITHOUT LIMITING THE SCOPE OF THE PRECEDING SENTENCE), YOU MAY NOT RECOVER FOR LOST PROFITS, LOST BUSINESS OPPORTUNITIES, OR OTHER TYPES OF SPECIAL, INCIDENTAL, INDIRECT, INTANGIBLE, OR CONSEQUENTIAL DAMAGES. SOME JURISDICTIONS DO NOT ALLOW THE EXCLUSION OR LIMITATION OF INCIDENTAL OR CONSEQUENTIAL DAMAGES, SO THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
      UNDER NO CIRCUMSTANCES SHALL WE BE REQUIRED TO DELIVER TO YOU ANY VIRTUAL CURRENCY AS DAMAGES, MAKE SPECIFIC PERFORMANCE OR ANY OTHER REMEDY. IF YOU WOULD BASE YOUR CALCULATIONS OF DAMAGES IN ANY WAY ON THE VALUE OF VIRTUAL CURRENCY, YOU AND WE AGREE THAT THE CALCULATION SHALL BE BASED ON THE LOWEST VALUE OF THE VIRTUAL CURRENCY DURING THE PERIOD BETWEEN THE ACCRUAL OF THE CLAIM AND THE AWARD OF DAMAGES.
      WE SHALL NOT BE LIABLE FOR ANY DAMAGES CAUSED IN WHOLE OR IN PART BY (A) THE MALFUNCTION, UNEXPECTED FUNCTION OR UNINTENDED FUNCTION OF ANY COMPUTER OR CRYPTOCURRENCY NETWORK, INCLUDING WITHOUT LIMITATION LOSSES ASSOCIATED WITH NETWORK FORKS, REPLAY ATTACKS, DOUBLE-SPEND ATTACKS, SYBIL ATTACKS, 51% ATTACKS, GOVERNANCE DISPUTES, MINING DIFFICULTY, CHANGES IN CRYPTOGRAPHY OR CONSENSUS RULES, HACKING OR CYBERSECURITY BREACHES; (B) THE CHANGE IN VALUE OF ANY CRYPTOCURRENCY; (C) ANY CHANGE IN LAW, REGULATION OR POLICY, OR (D) FORCE MAJEURE. THIS LIMITATION OF LIABILITY IS INTENDED TO APPLY WITHOUT REGARD TO WHETHER OTHER PROVISIONS OF THIS AGREEMENT HAVE BEEN BREACHED OR HAVE PROVEN INEFFECTIVE.
    </p>
    <p>
      12.5
      <i>Indemnification</i>. You agree to indemnify and hold harmless ISLB, its affiliates, subsidiaries, directors, managers, members, officers, and employees from any and all claims, demands, actions, damages, losses, costs or expenses, including without limitation, reasonable legal fees, arising out of or relating to your or any other person’s use of your credentials or User Account in connection with: (a) use of the ISLB Site or Services; (b) breach of this User Agreement or any other policy; (c) feedback or submissions you provide; (d) false, incomplete, or misleading information relied upon by us to verify your identity and source of funds, where applicable; or (e) violation of any rights of any other person or entity; provided however, that you shall not indemnify ISLB for claims or losses arising out of ISLB’s gross negligence or willful misconduct. This indemnity shall apply to your successors and assigns and shall survive any termination or cancellation of this User Agreement.
    </p>
    <p>12.6 Any and all of our indemnities, warranties, and limitations of liability (whether express or implied) are hereby excluded to the fullest extent permitted under law except as set forth herein. Nothing in this User Agreement excludes or limits liability which may not be limited or excluded under applicable law.</p>
    <h5>13. MISCELLANEOUS</h5>
    <p>
      13.1
      <i>Force Majeure</i>. If by reason in whole or in part of any Force Majeure Event, either you or ISLB is delayed or prevented from complying with this User Agreement, then such delay or non-compliance shall not be deemed to be a breach of this User Agreement and no loss or damage shall be claimed by you or ISLB by reason thereof. “Force Majeure Event” means any event beyond the party’s reasonable control, including, but not limited to, flood, extraordinary weather conditions, earthquake, or other act of God, fire, war, insurrection, riot, labor dispute, accident, action of government, communications, power failure, failure in bank performance, or equipment or software malfunction including network splits or “forks” or unexpected changes in a computer network upon which the Services rely.
    </p>
    <p>
      13.2
      <i>Taxes</i>. It is your responsibility to determine what, if any, taxes apply due to your use of ISLB Services, and it is your responsibility to report and remit the correct tax to the appropriate tax authority. ISLB is not responsible for determining whether taxes apply to your Virtual Currency transactions or for collecting, reporting, withholding or remitting any taxes arising from any virtual currency transactions.
    </p>
    <p>
      13.3
      <i>Severability, Reformation</i>. In the event that any provision of this User Agreement is unenforceable under applicable law, the validity or enforceability of the remaining provisions will not be affected. To the extent any provision of this User Agreement is judicially determined to be unenforceable, a court of competent jurisdiction may reform any such provision to make it enforceable. The provisions of this User Agreement will, where possible, be interpreted so as to sustain its legality and enforceability.
    </p>
    <p>
      13.4
      <i>Assignment</i>. This User Agreement shall be binding on your successors, heirs, personal representatives, and assigns. You may not assign or transfer any of your rights or obligations under this User Agreement without prior written consent of ISLB, which may be withheld in ISLB’s sole discretion. We may assign rights or delegate duties under this User Agreement in our sole discretion.
    </p>
    <p>
      13.5
      <i>Relationship of the Parties</i>. Nothing in this User Agreement is intended to, nor shall create any partnership, joint venture, agency, consultancy or trusteeship. You and ISLB are independent contractors for purposes of this User Agreement.
    </p>
    <p>
      13.6
      <i>Entire Agreement</i>. This User Agreement constitutes the entire agreement among the Parties with respect to the subject matter described herein and shall supersede all prior agreements and understandings, written or oral, among the Parties. Subsequent discussions or negotiations between you and ISLB or ISLB personnel shall only amend or become part of this User Agreement by way of a written amendment specifically referencing the last updated date and name of this User Agreement.
    </p>
    <p>
      13.7
      <i>Contact Information</i>. For any purpose other than technical support requests, you may contact us by registered post or courier: ISLB OÜ, Parnu mnt 158, 11317 Tallin, Estonia, email info@islb.one. For technical support requests only, you may submit a request via our Support tool at: info@islb.one . Email requests may also be sent to legal@islb.one.
    </p>

    <h5>14. DISPUTE RESOLUTION FOR UNITED STATES USERS</h5>
    <p>
      14.1
      <i>Disputes</i>. If you live in the United States (or, if you are a business, have your principal place of business in the United States), any dispute arising between you and us under this User Agreement or our relationship (whether arising out of contract, tort, statute or any other manner) shall be settled in binding arbitration, in accordance with the Federal Arbitration Act under the American Arbitration Association’s rules; provided, however, nothing in this Agreement will waive, preclude or otherwise limit your right to (i) bring an individual action in a U.S. small claims court or (ii) file a representative action solely to obtain a public injunction.
    </p>
    <p>
      14.2
      <i>Arbitration</i>. The arbitration will be conducted by a single, neutral arbitrator and shall take place in the county or parish of your billing address, or another mutually agreeable location, in the English language. The arbitrator shall apply the law of the state of New York, without regard to its conflict of laws principles. The arbitrator may award any relief that a court of competent jurisdiction could award, including attorneys' fees when authorized by law, and the arbitration decision may be enforced in any court. You agree that the arbitrator shall have the authority to order relief, and you agree to abide by all decisions and awards rendered in such a proceeding, which shall be final and conclusive. At your request, hearings may be conducted in person or by telephone and the arbitrator may provide for submitting and determining motions on briefs, without oral hearings. The prevailing party in any action or proceeding to enforce this agreement shall be entitled to reasonable costs and attorneys' fees.
    </p>
    <p>14.3 If the arbitrator(s) or administrator imposes filing fees or other administrative costs on you, we will reimburse you, upon request, to the extent such fees or costs would exceed those that you would otherwise have to pay if you were proceeding instead in a court. If a court decides that any provision of this section concerning Arbitration is invalid or unenforceable, that provision shall be severed and resolved in accordance with English law exclusively and the other parts of this section concerning Arbitration shall still apply. In no case shall the remainder of this User Agreement be affected. If the invalidity or unenforceability of a provision causes a dispute to proceed in a court instead of arbitration, the Parties agree that such court must be located in London, England, applying English law.</p>
    <p>
      14.4
      <i>No Trial by Jury</i>. By entering into this User Agreement, you expressly waive your right to a trial by jury and right to participate in a class action lawsuit.
    </p>

    <h5>15. DISPUTE RESOLUTION FOR NON-U.S. USERS</h5>
    <p>15.1 If you live outside of the United States (or, if you are a business, have your principal place of business outside of the United States), 
        any dispute arising between you and us under this User Agreement or our relationship (whether arising out of contract, tort, statute or any other manner), 
        the courts located in Tallin, Estonia shall have exclusive jurisdiction of such dispute, and will hear the dispute under Estonian law.</p>
  </div>
</template>
<script>
import Title from "./TitleBlock.vue";
import Legal from "../../views/LegalInfo";
export default {
  extends: Legal,
  components: {
    Title
  },
  beforeMount() {
      this.$parent.titleObj.name = "ISLB User Agreement";
      this.$parent.titleObj.lastUpdate = "November 8, 2019";
      this.$parent.titleObj.downloadLink = "https://pay.islb.one/il-doc/islb_terms.pdf"
  }
};
</script>
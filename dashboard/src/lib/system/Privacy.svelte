<script lang="ts">
    import { Card, CardHeader, CardBody, CardTitle, Row, Col, Button, Spinner } from 'sveltestrap';
    import {Link} from 'svelte-navigator';
    import FaUserLock from 'svelte-icons/fa/FaUserLock.svelte';
    import PrivacyEdit from './PrivacyEdit.svelte';

    import { System, SystemPrivacy } from '../../api/types';

    export let user: System;
    let editMode = false;

    let loading: boolean;

    const privacyNames: { [P in keyof SystemPrivacy]-?: string; } = {
		description_privacy: "Description",
        member_list_privacy: "Member list",
        front_privacy: "Front",
        front_history_privacy: "Front history",
        group_list_privacy: "Group list",
        pronoun_privacy: "Pronouns"
	};

</script>

<Card class="mb-4">
    <CardHeader>
        <CardTitle style="margin-top: 8px; outline: none;">
            <div class="icon d-inline-block">
                <FaUserLock />
            </div> System privacy
            {#if loading}<div class="d-inline-block mr-5" style="float: right;"><Spinner color="primary" /></div>{/if}
        </CardTitle>
    </CardHeader>
    <CardBody style="border-left: 4px solid #{user.color}">
        {#if editMode}
        <PrivacyEdit bind:user={user} bind:editMode/>
        {:else}
        <Row>
            {#each Object.keys(user.privacy) as x}
                <Col xs={12} lg={4} class="mb-3">
                    <b>{privacyNames[x]}:</b> {user.privacy[x]}
                </Col>
            {/each}
        </Row>
        <Button style="flex: 0" color="primary" on:click={() => editMode = true} aria-label="edit system privacy">Edit</Button>
        <Link to="/dash/bulk-member-privacy"><Button style="flex: 0" color="secondary" tabindex={-1}>Bulk member privacy</Button></Link>
        <Link to="/dash/bulk-group-privacy"><Button style="flex: 0" color="secondary" tabindex={-1}>Bulk group privacy</Button></Link>
        {/if}
    </CardBody>
</Card>